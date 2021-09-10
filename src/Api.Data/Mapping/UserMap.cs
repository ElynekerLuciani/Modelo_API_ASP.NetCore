using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
vai realizar o mapeamento dos atributos das entidades que estarão na
tabela do banco de dados definindo suas propriedades.
*/
namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Email).HasMaxLength(100);
        }
    }
}