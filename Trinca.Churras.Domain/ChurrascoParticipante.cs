namespace Trinca.Churras.Domain
{
    public class ChurrascoParticipante : Entity
    {
        public Guid ParticipanteId { get; set; }
        public Guid ChurrascoId { get; set; }
        public decimal ValorContribuicao { get; set; }

       
        public ChurrascoParticipante(Guid participanteId, Guid churrascoId, decimal valorContribuicao)
        {
            ParticipanteId = participanteId;
            ChurrascoId = churrascoId;
            ValorContribuicao = valorContribuicao;
        }
    }
}
