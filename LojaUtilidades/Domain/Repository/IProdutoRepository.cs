﻿using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
       Produto SelectByName(string nome);
       bool DeleteByName(string nome);
    }
}
