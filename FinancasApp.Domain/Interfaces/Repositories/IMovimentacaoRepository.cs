﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancasApp.Domain.Entities;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepository
    {
        void Add(Movimentacao movimentacao);
        void Update(Movimentacao movimentacao);
        void Delete(Guid id);
        Movimentacao? GetById(Guid id);
        List<Movimentacao> GetByDatas(DateOnly dataMin, DateOnly dataMax);
    }
}
