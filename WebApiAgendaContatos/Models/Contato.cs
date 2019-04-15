using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAgendaContatos.Models
{
    public class Contato
    {
        /// <summary>
        /// Id's contact
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name's contact
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Telephone's contact
        /// </summary>
        public string Telefone { get; set; }
    }
}
