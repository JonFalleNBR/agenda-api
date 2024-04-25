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

    }
}
