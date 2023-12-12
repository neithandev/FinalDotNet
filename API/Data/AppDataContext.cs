using Microsoft.EntityFrameworkCore;
namespace API.Data;
using API.Models;
public class AppDataContext: DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options):base(options){ }
    public DbSet<Aluno> Alunos{get;set;}
    public DbSet<Imc> Imcs{get;set;}
}
