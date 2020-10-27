using System;
using System.Collections.Generic;
using System.Net;
using ApiRestCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Obter todos os clientes.
        /// </summary>
        /// <response code="200">Lista de clientes obtidas com sucesso.</response>
        /// <response code="500">Erro ao obter a lista de clientes.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Client>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var usuarios = ObterUsuarios();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // Temporario || dados para teste
        private IEnumerable<Client> ObterUsuarios()
        {
            return new List<Client>
            {
                new Client { Name = "Andre",  Phone = "1196682203", Email = "andre@outlook.com", Comments = "Otimo cliente" },
                new Client { Name = "Fulano",  Phone = "1141432432", Email = "fulano@outlook.com", Comments = null },
                new Client { Name = "Ciclano",  Phone = "1196682203", Email = "andre@outlook.com", Comments = "Pendencia no Cadastro" },
                new Client { Name = "Teste",  Phone = "1196682203", Email = "andre@outlook.com", Comments = "Pendencia no cadastro" },
                new Client { Name = "Joao",  Phone = "1196682203", Email = "andre@outlook.com", Comments = null },
            };
        }
    }
}
