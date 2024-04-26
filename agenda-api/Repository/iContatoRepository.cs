using agenda_api.Model;

namespace agenda_api.Repository
{
    public interface iContatoRepository
    {

        void Add(Contato contato);

        Contato Get(int id);

        void Delete(Contato contato);
       
    }


    
}
