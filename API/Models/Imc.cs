namespace API.Models;

public class Imc{
    public Aluno? Aluno{get;set;}
    public int AlunoId{get;set;}
    public int Id {get;set;}
    public double Metros {get;set;}
    public double Peso{get;set;} 
    public double ValorImc{get;set;}
    public String? Classificacao {get;set;}
    public DateTime DataCadastro { get; set; }
    
}
