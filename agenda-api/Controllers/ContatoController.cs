using agenda_api.Infrastructure;
using agenda_api.Model;
using agenda_api.Repository;
using agenda_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers
{

    [ApiController]
    [Route ("api/v1/contato")]
    public class ContatoController : ControllerBase
    {

        private readonly iContatoRepository _contatoRepository;


        public ContatoController(iContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository  ?? throw new ArgumentNullException(nameof(contatoRepository));  
        }
        
        [HttpPost]
        public IActionResult Add(ContatoViewModel contatoViewModel)
        {
            var contato = new Contato(contatoViewModel.Nome, contatoViewModel.Email, contatoViewModel.Favorito);
            _contatoRepository.Add(contato);

            return Ok(contato);
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

            return Ok(contato); // Retorna o contato excluído
        }

    }
}
