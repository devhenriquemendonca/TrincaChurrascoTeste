using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinca.Churras.Domain
{
    public class Churrasco : Entity
    {
        public Churrasco(DateTime dataComemorativa, string descricao, string? observacaoAdicional, decimal valorSugeridoPorPessoa, decimal? valorAdicionalBebida)
        {
            DataComemorativa = dataComemorativa;
            Descricao = descricao;
            ObservacaoAdicional = observacaoAdicional;
            ValorSugeridoPorPessoa = valorSugeridoPorPessoa;
            ValorAdicionalBebida = valorAdicionalBebida;
        }

        public DateTime DataComemorativa { get; set; }
        public string Descricao { get; set; }
        public string? ObservacaoAdicional { get; set; }
        public decimal ValorSugeridoPorPessoa { get; set; }
        public decimal? ValorAdicionalBebida { get; set; }


    }
}
