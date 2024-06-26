﻿using agenda_api.Infrastructure;
using agenda_api.Model;
using agenda_api.Repository;
using agenda_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers
{

    [ApiController]
    [Route("api/v1/contato")]
    public class ContatoController : ControllerBase
    {

        private readonly iContatoRepository _contatoRepository;


        public ContatoController(iContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository ?? throw new ArgumentNullException(nameof(contatoRepository));
        }

        [HttpPost]
        public IActionResult Add(ContatoViewModel contatoViewModel)
        {
            var contato = new Contato(contatoViewModel.Nome, contatoViewModel.Email, contatoViewModel.Favorito);
            _contatoRepository.Add(contato);

            return Ok(contato);
        }



        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _contatoRepository.GetAll(); // Chama o método GetAll do repositório
            return Ok(lista);
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _contatoRepository.Get(id); // Recupera o contato pelo ID
            if (contato == null) // Verifica se o contato existe
            {
                return NotFound(); // Retorna 404 Not Found se o contato não for encontrado
            }

            _contatoRepository.Delete(contato); // Chama o método Delete do repository

            return Ok(contato);
        }


        [HttpPatch("{id}/favorito")]
        public IActionResult favorite(int id, bool favorito)
        {
            Contato contato = _contatoRepository.findById(id, favorito);

            if(contato != null)
            {
                contato.favorito = favorito;
                return Ok(contato);
            }
            else
            {
                return NotFound();
            }        
        }

        [HttpGet("paginacao")]
        public IActionResult ListarContatosPaginacao([FromQuery] int page = 1)
        {
            const int pageSize = 10;
            var contatos = _contatoRepository.GetAll()
                .OrderBy(c => c.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(contatos);
        }


    }
}
