using MediatR;
using Trinca.Churras.Application.Core;
using Trinca.Churras.Application.ViewModels;

namespace Trinca.Churras.Application.Queries
{
    public class RecuperarListaChurrascoQueries : IRequest<BaseResponse<List<ChurrascoViewModel>>>
    {

    }
}
