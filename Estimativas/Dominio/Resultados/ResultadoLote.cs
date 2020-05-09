using System;
using System.Collections.Generic;
using System.Linq;

namespace Estimativas.Dominio.Resultados
{
    public sealed class ResultadoLote
    {
        public ResultadoLote(string receita, int unidadesPorReceita, int quantidadeReceitas, Dictionary<string, decimal> valores)
        {
            Receita = receita;
            UnidadesPorReceita = unidadesPorReceita;
            QuantidadeReceitas = quantidadeReceitas;
            Valores = valores;
            ValorPorReceita = Valores.Sum(c => c.Value);
            ValorPorUnidade = ValorPorReceita / quantidadeReceitas;
            ValorTotal = ValorPorReceita * quantidadeReceitas;
            UnidadesGeradas = unidadesPorReceita * quantidadeReceitas;
        }

        public string Receita { get; }
        public int UnidadesPorReceita { get; }
        public int QuantidadeReceitas { get; }
        public Dictionary<string, decimal> Valores { get; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorPorReceita { get; private set; }
        public decimal ValorPorUnidade { get; private set; }
        public int UnidadesGeradas { get; private set; }
    }
}
