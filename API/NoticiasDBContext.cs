using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API{
    public class NoticiasDBContext: DbContext{
        public NoticiasDBContext(DbContextOptions opciones): base(opciones){

        }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloCreador){
            new Noticia.Mapeo(modeloCreador.Entity<Noticia>());
            new Autor.Mapeo(modeloCreador.Entity<Autor>());
        }
    }
}
