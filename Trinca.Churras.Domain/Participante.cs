namespace Trinca.Churras.Domain
{
    public class Participante : Entity
    {
        public string Nome { get; set; }

        public Participante(string nome)
        {
            Nome = nome;
        }

        public Participante()
        {
            
        }
    }
}
