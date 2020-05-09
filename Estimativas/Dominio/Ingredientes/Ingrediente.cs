using System;
using System.Xml.Serialization;

namespace Estimativas.Dominio.Ingredientes
{
    [Serializable()]
    [XmlRoot("Ingredientes")]
    public sealed class IngredienteCollection
    {
        [XmlArray("IngredientesCollection")]
        [XmlArrayItem("Ingrediente", typeof(Ingrediente))]
        public Ingrediente[] Ingredientes { get; set; }
    }

    public sealed class Ingrediente
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Nome")]
        public string Nome { get; set; }

        [XmlAttribute("Marca")]
        public string Marca { get; set; }

        [XmlAttribute("Preco")]
        public decimal Preco { get; set; }

        [XmlAttribute("Quantidade")]
        public int Quantidade { get; set; }

        [XmlAttribute("Classe")]
        public string Classe{ get; set; }
    }
}