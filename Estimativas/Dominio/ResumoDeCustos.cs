using System.Collections.Generic;

namespace Estimativas.Dominio
{
    public sealed class ResumoDeCustos
    {
        public ResumoDeCustos(Dictionary<string, float> custoPorIngrediente, float custoTotal)
        {
            CustoPorIngrediente = custoPorIngrediente;
            CustoTotal = custoTotal;
        }

        public Dictionary<string, float> CustoPorIngrediente { get; }
        public float CustoTotal { get; }
    }
}
