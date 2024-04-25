using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenda_api.Model
{
    [Table("contato")]
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public bool? favorito { get; set; }

        public Contato(string nome, string email, bool? favorito)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.email = email;
            this.favorito = favorito;
        }
    }
}
