using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;


namespace API.Controller;

[ApiController]
[Route("aluno")]
public class AlunoController : ControllerBase
{
    private readonly AppDataContext _context;
    public AlunoController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Aluno> alunos = _context.Alunos.ToList();
            return Ok(alunos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Aluno aluno)
    {
        try
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}
