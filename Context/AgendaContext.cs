using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_MVC.Models;

namespace Projeto_MVC.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base (options)
        {

        }
        
        public DbSet<Contato> contatos {get;set;}
    }
}