using System;
using System.Xml.Serialization;

namespace Estimativas.Dominio.Receitas
{
    [Serializable]
    [XmlRoot("Receitas")]
    public sealed class ReceitaCollection
    {
        [XmlArray("ReceitaCollection")]
        [XmlArrayItem("Receita")]
        public Receita[] Receitas { get; set; }
    }

    public sealed class Receita
    {
        [XmlAttribute("Nome")]
        public string Nome { get; set; }

        [XmlAttribute("Rendimento")]
        public int Rendimento { get; set; }

        [XmlArray("IngredientesReceita")]
        [XmlArrayItem("Ingrediente", typeof(IngredienteReceita))]
        public IngredienteReceita[] Ingredientes { get; set; }
    }


    public sealed class IngredienteReceita
    {
        [XmlAttribute("Classe")]
        public string ClasseIngrediente { get; set; }

        [XmlAttribute("Quantidade")]
        public int Quantidade { get; set; } 
    }
}
