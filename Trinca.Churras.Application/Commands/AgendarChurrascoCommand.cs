using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;

namespace Trinca.Churras.Application.Commands
{
    public class AgendarChurrascoCommand : IRequest<BaseResponse<Guid>>
    {
        public DateTime DataComemorativa { get; set; }
        public string Descricao { get; set; }
        public string? ObservacaoAdicional { get; set; }
        public decimal ValorSugeridoPorPessoa { get; set; }
        public decimal? ValorAdicionalBebida { get; set; }
    }
}
