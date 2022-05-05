using Application.V1.Handlers.ProvaHandlers.Queries.GetById;
using AutoMapper;
using Domain.Entities.Prova;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Dependencies).Assembly);
            return services;
        }
    }
}