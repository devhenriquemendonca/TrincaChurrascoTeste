using MediatR;
using Trinca.Churras.Application.Core;

namespace Trinca.Churras.Application.Commands
{
    public class IncluirParticipanteChurrascoCommand : IRequest<BaseResponse<Guid>>
    {
        public Guid ParticipanteId { get; set; }
        public Guid ChurrascoId { get; set; }
        public decimal ValorContribuicao { get; set; }

    }
}
