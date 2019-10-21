using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TotvsPreventBackOffice.Models;

namespace TotvsPreventBackOffice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<MetodoApi> MetodoApi { get; set; }
        public DbSet<Servidor> Servidor { get; set; }
        public DbSet<FilialColigada> FilialColigada { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<UserModuloPerfil> UserModuloPerfil { get; set; }
        public DbSet<Modulo> Modulo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
