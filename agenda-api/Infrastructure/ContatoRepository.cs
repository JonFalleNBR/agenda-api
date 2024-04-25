using agenda_api.Model;
using agenda_api.Repository;

namespace agenda_api.Infrastructure
{
    public class ContatoRepository : iContatoRepository
    {


        public readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
        }

        public List<Contato> Get()
        {
            return _context.contatos.ToList();
        }
    }
}
