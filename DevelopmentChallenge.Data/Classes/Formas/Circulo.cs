using DevelopmentChallenge.Data.Enums;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Circulo : FormaBase
    {
        public Circulo(decimal ancho) : base((int)Shapes.Circle, ancho)
        {
            Tipo = (int)Shapes.Circle;
            NombreSingular = Languages.strings.Circle;
            NombrePlural = Languages.strings.Circles;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (base.Lado / 2) * (base.Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * base.Lado;
        }
    }
}
