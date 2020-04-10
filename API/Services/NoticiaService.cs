using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services{
    public class NoticiaService{

        //Se declara esta variable para no tener que instanciar a la BD en cada método
        private readonly NoticiasDBContext _noticiaDbContext;
        public NoticiaService(NoticiasDBContext noticiaDbContext){
            _noticiaDbContext = noticiaDbContext;
        }

        //Obtiene todos los registros de la BD
        public List<Noticia> Obtener(){
            var resultado =_noticiaDbContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        //Agrega un registro, recibe un body con la noticia completa
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

        //Edita un registro
        public Boolean editarNoticia(Noticia _noticia){
            try{
                var noticiaBaseDeDatos = _noticiaDbContext.Noticia.Where(busqueda => busqueda.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBaseDeDatos.Titulo = _noticia.Titulo;
                noticiaBaseDeDatos.Descripcion = _noticia.Descripcion;
                noticiaBaseDeDatos.Contenido = _noticia.Contenido;
                noticiaBaseDeDatos.Fecha = _noticia.Fecha;
                noticiaBaseDeDatos.Autor = _noticia.Autor;

                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch (Exception){

                throw;
            }
        }

        //Borra un registro
        public Boolean eliminar(int NoticiaID){
            try{
                var noticiaBaseDeDatos = _noticiaDbContext.Noticia.Where(busqueda => busqueda.NoticiaID == NoticiaID).FirstOrDefault();
                _noticiaDbContext.Noticia.Remove(noticiaBaseDeDatos);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch (Exception){
                return false;
            }
        }
    }
}
