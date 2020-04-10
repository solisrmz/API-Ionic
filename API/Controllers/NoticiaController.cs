using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase{

        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService){
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult obtener(){
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }
    }
}