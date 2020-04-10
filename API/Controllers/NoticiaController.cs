using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase{

        //Se declara para no instaciar en cada método
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService){
            _noticiaService = noticiaService;
        }

        //Obtiene todos los registros
        [HttpGet]
        [Route("obtener")]
        public IActionResult obtener(){
            //Se llama al método en la clase NoticiaService
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }

        //Agrega un registro
        [HttpPost]
        [Route("agregar")]
        public IActionResult agregar([FromBody] Noticia _noticia){
            var resultado = _noticiaService.agregarNoticia(_noticia);
            //Si inserta devuelve un true, entonces se retorna un response 200 OK
            if (resultado){
                return Ok();
            }
            //Si no registra, devuelve un false y retorna un 400 BadRequest
            else
            {
                return BadRequest();
            }
        }

        //Editar un registro
        [HttpPut]
        [Route("editar")]
        public IActionResult editar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.editarNoticia(_noticia);
            //Si realiza los cambios devuelve un true, entonces se retorna un response 200 OK
            if (resultado){
                return Ok();
            }
            //Si no registra, devuelve un false y retorna un 400 BadRequest
            else{
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar/{NoticiaID}")]
        public IActionResult eliminar(int NoticiaID){
            var resultado = _noticiaService.eliminar(NoticiaID);
            //Si elimina devuelve un true, entonces se retorna un response 200 OK
            if (resultado){
                return Ok();
            }
            //Si no elimina, devuelve un false y retorna un 400 BadRequest
            else
            {
                return BadRequest();
            }
        }
    }
}