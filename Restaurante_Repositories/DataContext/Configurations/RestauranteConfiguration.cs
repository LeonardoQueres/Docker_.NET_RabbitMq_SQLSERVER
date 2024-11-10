using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante_Borders.Entities;

namespace Restaurante_Repositories.DataContext.Configurations
{
    public class RestauranteConfiguration : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasData(
                                new Restaurante
                                {
                                    Id = Guid.NewGuid(),
                                    Endereco = "Rua dos Testes",
                                    Nome = "Restaurante do Queres",
                                    Site = "queres.com.br",
                                    DataCriacao = DateTime.Now.ToLocalTime()
                                },
                                new Restaurante
                                {
                                    Id = Guid.NewGuid(),
                                    Endereco = "Rua dos Desenvolvedores",
                                    Nome = "Restaurante dos Desenvolvedores",
                                    Site = "desenvolvedores.com.br",
                                    DataCriacao = DateTime.Now.AddDays(3).ToLocalTime()
                                }
                            );
        }
    }
}
