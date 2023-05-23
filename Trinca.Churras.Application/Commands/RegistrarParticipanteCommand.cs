using MediatR;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;

namespace Trinca.Churras.Application.Commands
{
    public class RegistrarParticipanteCommand : IRequest<BaseResponse<Guid>>
    {
        public string Nome { get; set; }
    }
}
