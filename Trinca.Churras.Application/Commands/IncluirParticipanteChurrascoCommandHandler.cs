using MediatR;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Domain;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Commands
{
    public class IncluirParticipanteChurrascoCommandHandler : IRequestHandler<IncluirParticipanteChurrascoCommand, BaseResponse<Guid>>
    {
        private readonly ChurrascoContext _context;

        public IncluirParticipanteChurrascoCommandHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }


        public async Task<BaseResponse<Guid>> Handle(IncluirParticipanteChurrascoCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<Guid> response = new();

            if (request.ValorContribuicao < 0)
            {
                response.AddError(new ErrorResponse("O Valor de contribuição deve ser maior que 0."), System.Net.HttpStatusCode.BadRequest);
                return response;
            }

            if (!_context.Participante.Any(x => x.Id == request.ParticipanteId))
            {
                response.AddError(new ErrorResponse("O partipante informado não existe."), System.Net.HttpStatusCode.BadRequest);
                return response;

            }

            if (!_context.Churrasco.Any(x => x.Id == request.ChurrascoId))
            {
                response.AddError(new ErrorResponse("O Churrasco informado não existe."), System.Net.HttpStatusCode.BadRequest);
                return response;

            }

            var churrascoParticipante = new ChurrascoParticipante(request.ParticipanteId, request.ChurrascoId, request.ValorContribuicao);
            await _context.ChurrascoParticipante.AddAsync(churrascoParticipante);
            await _context.SaveChangesAsync(cancellationToken);

            response.AddData(churrascoParticipante.Id, System.Net.HttpStatusCode.OK);
            return response;
        }
    }
}
