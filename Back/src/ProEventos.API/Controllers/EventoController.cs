using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {   
    public IEnumerable<Evento> _evento = new Evento[]{
        new Evento(){
        
        EventoId = 1,
        Tema = "Angular e dotnet core",
        Local = "Imperatriz",
        Lote = "Lote 1",
        QtdPessoas = 250,
        DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        ImagemURL = "foto.png" 
        },
        new Evento(){
        
        EventoId = 2,
        Tema = "Angular e dotnet core web api",
        Local = "São luiz",
        Lote = "Lote 2",
        QtdPessoas = 260,
        DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        ImagemURL = "foto1.png" 
        }                                 
            };

        public EventoController()
        {
        
        }

        [HttpGet]
        public IEnumerable<Evento>  Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByID(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Post exemplo";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put exemplo com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"delete exemplo com id = {id}";
        }
    }
}
