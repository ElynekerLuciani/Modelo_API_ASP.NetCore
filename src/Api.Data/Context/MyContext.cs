using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

/*
esse contexto recebe as tabelas relacionadas a entidades no domínio
e vai conectar com os serviços do banco de dados;
*/
namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            //Ao iniciar a criação cadastrar um usuário padrão
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@mail.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );

        }

    }
}