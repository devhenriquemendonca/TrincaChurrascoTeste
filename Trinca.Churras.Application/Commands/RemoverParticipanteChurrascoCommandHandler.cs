using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Domain;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Commands
{
    public class RemoverParticipanteChurrascoCommandHandler : IRequestHandler<RemoverParticipanteChurrascoCommand, BaseResponse<object>>
    {
        private readonly ChurrascoContext _context;

        public RemoverParticipanteChurrascoCommandHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<BaseResponse<object>> Handle(RemoverParticipanteChurrascoCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<object> response = new();

            var churrascoParticipante = await _context.ChurrascoParticipante.FirstOrDefaultAsync(x => x.Id == request.ChurrascoParticipanteId);
            _context.ChurrascoParticipante.Remove(churrascoParticipante);
            await _context.SaveChangesAsync(cancellationToken);

            response.SetStatusCode(System.Net.HttpStatusCode.OK);
            return response;
        }
    }
}
