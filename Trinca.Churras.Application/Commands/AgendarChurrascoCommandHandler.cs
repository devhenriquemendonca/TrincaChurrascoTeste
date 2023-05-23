using MediatR;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Domain;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Commands
{
    public class AgendarChurrascoCommandHandler : IRequestHandler<AgendarChurrascoCommand, BaseResponse<Guid>>
    {
        private readonly ChurrascoContext _context;

        public AgendarChurrascoCommandHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<BaseResponse<Guid>> Handle(AgendarChurrascoCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<Guid> response = new();

            if (request.DataComemorativa.Date < DateTime.Now.Date)
            {
                response.AddError(new ErrorResponse("A data comemorativa não anteceder a data de Hoje."), System.Net.HttpStatusCode.BadRequest);
                return response;
            }

            var churrasco = new Churrasco(request.DataComemorativa, request.Descricao, request.ObservacaoAdicional, request.ValorSugeridoPorPessoa, request.ValorAdicionalBebida);
            await _context.Churrasco.AddAsync(churrasco);
            await _context.SaveChangesAsync(cancellationToken);

            response.AddData(churrasco.Id, System.Net.HttpStatusCode.OK);
            return response;

        }
    }
}
