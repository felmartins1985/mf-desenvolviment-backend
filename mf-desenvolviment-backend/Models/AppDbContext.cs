using Microsoft.EntityFrameworkCore;

namespace mf_desenvolviment_backend.Models
{
    // responsavel por fazer a configuração do Entity Framework, mapeando as classes do modelo para as tabelas do banco de dados
    public class AppDbContext: DbContext // estou configurando o contexto da aplicacao utilizando o entity framework
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) // construtor que recebe as opcoes de configuracao do contexto
        {
        }
        public DbSet<Veiculo> Veiculos { get; set; } // propriedade que representa a tabela de veiculos no banco de dados
        // toda entidade nova que for criada é preciso inserir uma nova propriedade DbSet<>

        public DbSet<Consumo> Consumos { get; set; } // propriedade que representa a tabela de consumos no banco de dados
    }
}
