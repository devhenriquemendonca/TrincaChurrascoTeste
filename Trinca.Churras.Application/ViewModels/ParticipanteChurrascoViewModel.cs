using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinca.Churras.Application.ViewModels
{
    public class ParticipanteChurrascoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorContribuicao { get; set; }
    }
}
