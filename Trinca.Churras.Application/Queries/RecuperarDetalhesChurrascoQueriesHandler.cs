using MediatR;
using Microsoft.EntityFrameworkCore;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.Application.Queries
{
    public class RecuperarDetalhesChurrascoQueriesHandler : IRequestHandler<RecuperarDetalhesChurrascoQueries, BaseResponse<ChurrascoViewModel>>
    {
        private readonly ChurrascoContext _context;

        public RecuperarDetalhesChurrascoQueriesHandler(ChurrascoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<BaseResponse<ChurrascoViewModel>> Handle(RecuperarDetalhesChurrascoQueries request, CancellationToken cancellationToken)
        {
            BaseResponse<ChurrascoViewModel> response = new();

            var churrascoViewModel = await _context.Churrasco.Select(x => new ChurrascoViewModel() { Id = request.Id, DataComemorativa = x.DataComemorativa, Descricao = x.Descricao}).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (churrascoViewModel is null)
            {
                response.AddError(new ErrorResponse("O Churrasco Não Existe."), System.Net.HttpStatusCode.BadRequest);
                return response;
            }

            var churrascoParticipantes = await _context.ChurrascoParticipante.Where(x => x.ChurrascoId == request.Id).ToListAsync(cancellationToken);

            var participantesIds = churrascoParticipantes.Select(x => x.ParticipanteId).ToList();

            var participantes = await _context.Participante.Where(x => participantesIds.Contains(x.Id)).ToListAsync(cancellationToken);

            foreach (var churrascoParticipante in churrascoParticipantes)
            {
                var participante = new ParticipanteChurrascoViewModel()
                {
                    Id = churrascoParticipante.Id,
                    ValorContribuicao = churrascoParticipante.ValorContribuicao,
                    Nome = participantes.FirstOrDefault(x => x.Id == churrascoParticipante.ParticipanteId).Nome
                };

                churrascoViewModel.Participantes.Add(participante);

            }

            churrascoViewModel.TotalParticipantes = churrascoViewModel.Participantes.Count();
            churrascoViewModel.TotalContribuicao = churrascoViewModel.Participantes.Sum(x => x.ValorContribuicao);
            response.AddData(churrascoViewModel, System.Net.HttpStatusCode.OK);
            return response;
        }
    }
}
