using Estimativas.Dominio.Ingredientes;
using Estimativas.Dominio.Lotes;
using Estimativas.Dominio.Receitas;
using Estimativas.Dominio.Resultados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Estimativas
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new ClasseIngredientes[] { };
            var ingredientes = new Ingrediente[] { };
            var receitas = new Receita[] { };
            var lotes = new Lote[] { };

            string path = $"{Directory.GetCurrentDirectory()}\\Resources\\";
            string xmlIngredientes = "Ingredientes.xml";
            string xmlReceitas = "Receitas.xml";
            string xmlLotes = "Lotes.xml";
            string xmlClassesIngredientes = "ClassesIngredientes.xml";

            var classesSerializer = new XmlSerializer(typeof(ClasseIngredientesCollection));
            using (StreamReader reader = new StreamReader($"{path}{xmlClassesIngredientes}"))
                classes = ((ClasseIngredientesCollection)classesSerializer.Deserialize(reader)).ClassesIngredientes;

            var ingredientesSerializer = new XmlSerializer(typeof(IngredienteCollection));
            using (StreamReader reader = new StreamReader($"{path}{xmlIngredientes}"))
                ingredientes = ((IngredienteCollection)ingredientesSerializer.Deserialize(reader)).Ingredientes;

            var receitasSerialize = new XmlSerializer(typeof(ReceitaCollection));
            using (StreamReader reader = new StreamReader($"{path}{xmlReceitas}"))
                receitas = ((ReceitaCollection)receitasSerialize.Deserialize(reader)).Receitas;

            var lotesSerializer = new XmlSerializer(typeof(LoteCollection));
            using (StreamReader reader = new StreamReader($"{path}{xmlLotes}"))
                lotes = ((LoteCollection)lotesSerializer.Deserialize(reader)).Lotes;

            var valoresLotes = new List<ResultadoLote>();
            foreach (var lote in lotes)
            {
                var valoresIngredientes = new Dictionary<string, decimal>();
                var receita = receitas.FirstOrDefault(r => r.Nome == lote.Receita);
                foreach (var ingrediente in receita.Ingredientes)
                {
                    var produto = ingredientes.FirstOrDefault(i => i.Classe == ingrediente.ClasseIngrediente);
                    var custoPorQuantidade = produto.Preco / produto.Quantidade;
                    var custoTotal = custoPorQuantidade * ingrediente.Quantidade;
                    valoresIngredientes.Add(produto.Classe, custoTotal);
                }
                valoresLotes.Add(new ResultadoLote(receita.Nome, receita.Rendimento, lote.Quantidade, valoresIngredientes));
            }

            foreach (var lote in valoresLotes)
            {
                Console.WriteLine($"Receita: {lote.Receita}");
                Console.WriteLine(String.Format("Valor total: {0:C}", lote.ValorTotal));
                Console.WriteLine(String.Format("Unidades geradas: {0}", lote.UnidadesGeradas));
                Console.WriteLine(String.Format("Custo por unidade: {0:C}", lote.ValorPorUnidade));
                Console.WriteLine(String.Format("Quantidade de receitas utilizadas: {0}", lote.QuantidadeReceitas));
                Console.WriteLine(String.Format("Valor por receita: {0:C}", lote.ValorPorReceita));
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}