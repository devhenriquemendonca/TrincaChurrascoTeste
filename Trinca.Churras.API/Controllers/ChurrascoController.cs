using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Trinca.Churras.Application.Commands;
using Trinca.Churras.Application.Queries;
using Trinca.Churras.Application.ViewModels;
using Trinca.Churras.Domain;
using Trinca.Churras.Infra.Data;

namespace Trinca.Churras.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChurrascoController : BaseController
    {
        private readonly ChurrascoContext _context;
        private readonly IMediator _mediator;

        public ChurrascoController(ChurrascoContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("participantes")]
        public async Task<IActionResult> RecuperarParticipantes()
        {
            return Ok(_context.Participante.ToList());
        }

        //[HttpGet]
        //[Route("churrascos")]
        //public async Task<IActionResult> RecuperarChurrasco()
        //{
        //    return Ok(_context.Churrasco.ToList());
        //}

        [HttpPost]
        [Route("cadastrar-participante")]
        public async Task<IActionResult> RegistrarParticipantes(RegistrarParticipanteCommand participante)
        {
            var result = await _mediator.Send(participante);
            return BaseResponse(result);
        }

        [HttpPost]
        [Route("agendar-churrasco")]
        public async Task<IActionResult> AgendarChurrasco(AgendarChurrascoCommand churrasco)
        {
            var result = await _mediator.Send(churrasco);
            return BaseResponse(result);
        }

        [HttpPost]
        [Route("incluir-participante-churrasco")]
        public async Task<IActionResult> IncluirParticipanteChurrasco(IncluirParticipanteChurrascoCommand churrasco)
        {
            var result = await _mediator.Send(churrasco);
            return BaseResponse(result);
        }

        [HttpGet]
        [Route("churrasco-detalhe/{id}")]
        public async Task<IActionResult> RecuperarDetalhesChurrasco(Guid id)
        {
            var result = await _mediator.Send(new RecuperarDetalhesChurrascoQueries() { Id = id});
            return BaseResponse(result);
        }

        [HttpDelete]
        [Route("remover-participante-churrasco/{id}")]
        public async Task<IActionResult> RemoverParticipanteChurrasco(Guid id)
        {
            var result = await _mediator.Send(new RemoverParticipanteChurrascoCommand() { ChurrascoParticipanteId = id });
            return BaseResponse(result);
        }

        [HttpGet]
        [Route("churrascos")]
        public async Task<IActionResult> RecuperarChurrascos()
        {
            var result = await _mediator.Send(new RecuperarListaChurrascoQueries() {  });
            return BaseResponse(result);
        }
    }
}
