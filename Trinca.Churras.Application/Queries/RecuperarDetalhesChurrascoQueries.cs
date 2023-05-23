using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;

namespace Trinca.Churras.Application.Queries
{
    public class RecuperarDetalhesChurrascoQueries : IRequest<BaseResponse<ChurrascoViewModel>>
    {
        public Guid Id { get; set; }
    }
}
