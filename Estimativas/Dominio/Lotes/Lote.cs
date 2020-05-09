using Estimativas.Dominio.Receitas;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Estimativas.Dominio.Lotes
{
    [Serializable()]
    [XmlRoot("Lote")]
    public sealed class LoteCollection
    {
        [XmlArray("LoteCollection")]
        [XmlArrayItem("Lote", typeof(Lote))]
        public Lote[] Lotes { get; set; }
    }

    public sealed class Lote
    {
        [XmlAttribute("Receita")]
        public string Receita { get; set; }
        
        [XmlAttribute("Data")]
        public DateTime Data { get; set; }

        [XmlAttribute("Quantidade")]
        public int Quantidade { get; set; }

        [XmlArray("IngredientesLoteCollection")]
        [XmlArrayItem("LoteIngrediente", typeof(LoteIngrediente))]
        public List<LoteIngrediente> Ingredientes{ get; set; }
    }

    public sealed class LoteIngrediente
    {
        [XmlAttribute("LoteClasseIngrediente")]
        public string Classe { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
