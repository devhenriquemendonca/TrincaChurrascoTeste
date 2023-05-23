using MediatR;
using Trinca.Churras.Application.Core;

namespace Trinca.Churras.Application.Commands
{
    public class RemoverParticipanteChurrascoCommand : IRequest<BaseResponse<object>>
    {
        public Guid ChurrascoParticipanteId { get; set; }
    }
}
