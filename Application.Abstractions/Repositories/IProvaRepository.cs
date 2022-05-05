using Domain.Entities.Prova;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface IProvaRepository
    {
        Task<List<Prova>> GetAll();
        Task<Prova> Get(FilterDefinition<Prova> filter);
        Task<Prova> Add(Prova prova);
        Task<Prova> Update(FilterDefinition<Prova> filter, UpdateDefinition<Prova> update);
    }
}
