﻿using Fiap.Web.Exercicio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Exercicio.Contexts
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public GameStoreContext(DbContextOptions o) : base(o)
        {

        }
    }
}
