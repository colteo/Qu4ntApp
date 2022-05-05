using Application.Abstractions.Repositories;
using Domain.Entities.Prova;
using MongoDB.Driver;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProvaRepository : IProvaRepository
    {
        private readonly ProvaDbContext _context;
        public ProvaRepository(ProvaDbContext context)
        {
            _context = context;
        }
        public async Task<Prova> Add(Prova prova)
        {
            _context.Prove.InsertOne(prova);
            return prova;
        }

        public async Task<List<Prova>> GetAll()
        {
            return _context.Prove.Find(Builders<Prova>.Filter.Empty).ToList();
        }

        public async Task<Prova> Get(FilterDefinition<Prova> filter)
        {
            return _context.Prove.Find(filter).FirstOrDefault();
        }

        public async Task<Prova> Update(FilterDefinition<Prova> filter, UpdateDefinition<Prova> update)
        {
            var result = _context.Prove.UpdateOne(filter, update);
            return await Get(filter);
        }
    }
}
