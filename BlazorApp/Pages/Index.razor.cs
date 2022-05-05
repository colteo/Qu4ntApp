using Application.V1.Handlers.ProvaHandlers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Index
    {
        [Inject] public IMediator _mediator { get; set; }
        public List<GetAllProveDTO> Prove { get; set; }
        protected override async void OnInitialized()
        {
            //Prove = await _mediator.Send(new GetAllProveRequest());
            base.OnInitialized();
        }
    }
}
