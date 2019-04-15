using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAgendaContatos.Models
{
    public class AgendaContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public AgendaContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Contatos entity
        /// </summary>
        public DbSet<Contato> Contatos { get; set; }
    }
}
