using AutoMapper;
using DesafioBackEndDevIII.Api.DTO;
using DesafioBackEndDevIII.Domain.Clientes;
using DesafioBackEndDevIII.Domain.Clientes.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioBackEndDevIII.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        // GET: api/V1.0/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(_clienteService.ObterClientes()));
        }

        // GET api/V1.0/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_mapper.Map<ClienteDto>(_clienteService.ObterClientePorId(id)));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] ClienteDto cliente)
        {
            _clienteService.AdicionarCliente(_mapper.Map<Cliente>(cliente));
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _clienteService.RemoverCliente(id);
        }
    }
}
