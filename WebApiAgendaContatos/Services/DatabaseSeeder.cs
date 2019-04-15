﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApiAgendaContatos.Models;

namespace WebApiAgendaContatos.Services
{
    public class DatabaseSeeder
    {
        /// <summary>
        /// DI to database context (in memory)
        /// </summary>
        private readonly AgendaContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"></param>
        public DatabaseSeeder(AgendaContext context)
        {
            _context = context;
            //logger.Info("Initial data seed started...");
            SeedDatabase();
            //logger.Info("Initial data seed finished...");
        }

        /// <summary>
        /// Seed the in memory database with initial data.
        /// </summary>
        public void SeedDatabase()
        {
            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Contato { Nome = "Thaiz", Telefone = "11 11111-1111" });
                _context.Contatos.Add(new Contato { Nome = "Daniel", Telefone = "11 22222-22222" });
                _context.Contatos.Add(new Contato { Nome = "Willian", Telefone = "15 99751-0298" });
                _context.Contatos.Add(new Contato { Nome = "Moreno", Telefone = "11 33333-3333" });
                _context.Contatos.Add(new Contato { Nome = "W12 Evo", Telefone = "11 3529-2801" });
                
                _context.SaveChanges();
            }
        }
    }
}
