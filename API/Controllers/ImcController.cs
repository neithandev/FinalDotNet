using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controller;

[ApiController]
[Route("imc")]
public class ImcController : ControllerBase
{
    private readonly AppDataContext _context;
    public ImcController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Imc> imcs = _context.Imcs
            .Include(x => x.Aluno)
            .ToList();
            return Ok(imcs);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Imc imc)
    {
        try
        {
            Aluno? aluno = _context.Alunos.Find(imc.AlunoId);

            double imcValor = imc.Peso / (imc.Metros * imc.Metros);
            string classificacao = ClassificacaoImc(imcValor);

            Imc novoImc = new Imc
            {
                Metros = imc.Metros,
                Peso = imc.Peso,
                Aluno = aluno,
                AlunoId = imc.AlunoId,
                ValorImc = imcValor,
                Classificacao = classificacao,
                DataCadastro = DateTime.Now
            };

            _context.Add(novoImc);
            _context.SaveChanges();
            return Ok(novoImc);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    [HttpPut("alterarimc/{id}")]
    public IActionResult AtualizarImc([FromRoute] int id, [FromBody] Imc imc)
    {
        try
        {
            Imc imcCadastrado = _context.Imcs.Include(x => x.Aluno).FirstOrDefault(x => x.Id == id);

            Aluno alunoCadastrado = _context.Alunos.Find(imc.AlunoId);
            imcCadastrado.Peso = imc.Peso;
            imcCadastrado.Metros = imc.Metros;
            imcCadastrado.ValorImc = imc.Peso / (imc.Metros * imc.Metros);
            imcCadastrado.Classificacao = ClassificacaoImc(imcCadastrado.ValorImc);

            if (imcCadastrado.AlunoId != imc.AlunoId)
            {
                Aluno novoAluno = _context.Alunos.Find(imc.AlunoId);
            }

            _context.Update(imcCadastrado);
            _context.SaveChanges();

            return Ok(imcCadastrado);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    private string ClassificacaoImc(double imc)
    {
        if (imc < 18.5)
        {
            return "Indice de MAGREZA";
        }
        else if (imc < 24.9)
        {
            return "Indice NORMAL";
        }
        else if (imc < 29.9)
        {
            return "Indice de SOBREPESO";
        }
        else if (imc < 39.9)
        {
            return "Indice de OBESIDADE";
        }
        else
        {
            return "Indice de OBESIDADE GRAVE";
        }
    }
}