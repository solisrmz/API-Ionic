using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services{
    public class NoticiaService{
        private readonly NoticiasDBContext _noticiaDbContext;
        public NoticiaService(NoticiasDBContext noticiaDbContext){
            _noticiaDbContext = noticiaDbContext;
        }

        public List<Noticia> Obtener(){
            var resultado =_noticiaDbContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        public Boolean agregarNoticia(Noticia _noticia){
            try{
                _noticiaDbContext.Noticia.Add(_noticia);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch (Exception error){
                  return false;
            }
        }
    }
}
