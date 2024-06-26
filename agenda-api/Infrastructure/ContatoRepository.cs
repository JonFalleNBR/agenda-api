﻿using agenda_api.Model;
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

        public Contato Get(int id)
        {
            return _context.contatos.FirstOrDefault(c => c.id == id);
        }

        public void Delete(Contato contato)
        {
            _context.contatos.Remove(contato);
            _context.SaveChanges();

        }

        public List<Contato> GetAll()
        {
            return _context.contatos.ToList();
        }

        public Contato findById(int id, bool favorito)
        {
           if(favorito)
            {
                return _context.contatos.FirstOrDefault(c => c.id == id && c.favorito == true);
                _context.SaveChanges();
            }
            else
            {
                return _context.contatos.FirstOrDefault(c => c.id == id && c.favorito == false);
            }
           

        }

    
    }
       
}
