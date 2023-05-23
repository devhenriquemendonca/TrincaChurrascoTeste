namespace Trinca.Churras.Application.ViewModels
{
    public class ChurrascoViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataComemorativa { get; set; }
        public string Descricao { get; set; }
        public string? ObservacaoAdicional { get; set; }
        public int TotalParticipantes { get; set; }
        public decimal TotalContribuicao { get; set; }

        public List<ParticipanteChurrascoViewModel> Participantes { get; set; } = new List<ParticipanteChurrascoViewModel>();

    }
}
