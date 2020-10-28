using System;
using System.Collections.Generic;
using System.Net;
using ApiRestCore.Data;
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
                var clients = new ClientRepository().GetAllClients();
                return Ok(clients);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Obter um cliente específico por ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <response code="200">Cliente obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado cliente com ID especificado.</response>
        /// <response code="500">Erro ao obter o cliente.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = new ClientRepository().GetClient(id);

                if (cliente == null)
                    return NotFound("Usuário não encontrado.");

                return Ok(cliente);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Cadastrar cliente.
        /// </summary>
        /// <param name="client">Modelo do cliente.</param>
        /// <response code="201">Cliente cadastrado com sucesso.</response>
        /// <response code="400">Cliente inválido.</response>
        /// <response code="500">Erro ao cadastrar o cliente.</response>
        [HttpPost]
        public IActionResult Post(Client client)
        {
            try
            {
                int rows = new ClientRepository().Save(client);

                if (rows == 0)
                    return Ok("Cliente não foi salvo no banco!");
                else
                    return Ok("Cliente salvo com sucesso!");
                //return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Alterar cliente.
        /// </summary> 
        /// <param name="cliente">Modelo do cliente.</param>
        /// <response code="200">Cliente alterado com sucesso.</response>
        /// <response code="400">O modelo do cliente enviado é inválido.</response>
        /// <response code="404">Não foi encontrado cliente com ID especificado.</response>
        /// <response code="500">Erro ao alterar o cliente.</response>
        [HttpPut]
        public IActionResult Put([FromBody] Client cliente)
        {
            try
            {
                int row = new ClientRepository().Update(cliente);

                if (row == 0)
                    return NotFound("Cliente não encontrado.");
                else
                    return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletar cliente.
        /// </summary>
        /// <param name="id">ID do Cliente.</param>
        /// <response code="200">Cliente deletado com sucesso.</response>
        /// <response code="404">Não foi encontrado cliente com ID especificado.</response>
        /// <response code="500">Erro ao deletar o cliente.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int row = new ClientRepository().Delete(id);

                if (row == 0)
                    return NotFound("Cliente não encontrado.");
                else
                    return Ok("Cliente deletado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
