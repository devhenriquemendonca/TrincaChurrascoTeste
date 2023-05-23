using MediatR;
using Microsoft.EntityFrameworkCore;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Queries
{
    public class RecuperarListaChurrascoQueriesHandler : IRequestHandler<RecuperarListaChurrascoQueries, BaseResponse<List<ChurrascoViewModel>>>
    {
        private readonly ChurrascoContext _context;

        public RecuperarListaChurrascoQueriesHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<BaseResponse<List<ChurrascoViewModel>>> Handle(RecuperarListaChurrascoQueries request, CancellationToken cancellationToken)
        {
            BaseResponse<List<ChurrascoViewModel>> response = new();

            var churrascos = await _context.Churrasco.Select(x => new ChurrascoViewModel() { Id = x.Id, DataComemorativa = x.DataComemorativa, Descricao = x.Descricao }).ToListAsync(cancellationToken) ; 

            var churrascoParticipantes = await _context.ChurrascoParticipante.ToListAsync(cancellationToken);

            var participantesIds = churrascoParticipantes.Select(x => x.ParticipanteId).ToList();

            var participantes = await _context.Participante.Where(x => participantesIds.Contains(x.Id)).ToListAsync(cancellationToken);

            foreach (var churrasco in churrascos)
            {
                churrasco.TotalParticipantes = churrascoParticipantes.Where(x => x.ChurrascoId == churrasco.Id).Count();
                churrasco.TotalContribuicao = churrascoParticipantes.Where(x => x.ChurrascoId == churrasco.Id).Sum(x => x.ValorContribuicao);

            }

            response.AddData(churrascos, System.Net.HttpStatusCode.OK);

            return response;
        }
    }
}
