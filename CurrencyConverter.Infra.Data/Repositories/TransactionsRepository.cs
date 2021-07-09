﻿using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infra.Data.Repositories
{
    public class TransactionsRepository : BaseRepository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(SqlDbContext context) : base(context) { }
    }
}
