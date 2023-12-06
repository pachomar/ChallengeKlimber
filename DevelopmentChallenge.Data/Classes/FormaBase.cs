using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public partial class FormaBase : IFormaBase
    {
        public decimal Lado { get; set; }
        public int Tipo { get; set; }
        public string NombreSingular { get; set; }
        public string NombrePlural { get; set; }

        public FormaBase(int tipo, decimal ancho)
        {
            Lado = ancho;
            Tipo = tipo;
        }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public string ObtenerNombre(bool singular)
        {
            return singular ? NombreSingular : NombrePlural;
        }
    }
}
