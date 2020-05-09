using System;
using System.Xml.Serialization;

namespace Estimativas.Dominio.Ingredientes
{
    [Serializable()]
    [XmlRoot("Classes")]
    public sealed class ClasseIngredientesCollection
    {
        [XmlArray("ClassesIngredientes")]
        [XmlArrayItem("Classe", typeof(ClasseIngredientes))]
        public ClasseIngredientes[] ClassesIngredientes{ get; set; }
    }

    public sealed class ClasseIngredientes
    {
        [XmlAttribute("Nome")]
        public string Nome { get; set; }

        [XmlAttribute("Unidade")]
        public string Unidade { get; set; }
    }
}
