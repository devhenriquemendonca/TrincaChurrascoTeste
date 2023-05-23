using MediatR;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;
using Trinca.Churras.Domain;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Commands
{
    public class RegistrarParticipanteCommandHandler : IRequestHandler<RegistrarParticipanteCommand, BaseResponse<Guid>>
    {
        private readonly ChurrascoContext _context;

        public RegistrarParticipanteCommandHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<BaseResponse<Guid>> Handle(RegistrarParticipanteCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<Guid> response = new();

            if(request.Nome.Length < 3)
            {
                response.AddError(new ErrorResponse("O Nome deve conter mais que 3 caracteres."), System.Net.HttpStatusCode.BadRequest);
                return response;
            }

            var participante = new Participante(request.Nome);
            await _context.Participante.AddAsync(participante);
            await _context.SaveChangesAsync(cancellationToken);

            response.AddData(participante.Id, System.Net.HttpStatusCode.OK);
            return response;
        }
    }
}
