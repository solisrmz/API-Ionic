﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models{
    public class Autor
    {
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }


        //Mapeo de las tablas de la BD
        public class Mapeo{
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor){
                mapeoAutor.HasKey(x => x.AutorID);
                mapeoAutor.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoAutor.ToTable("Autor");
            }
        }
    }
}
