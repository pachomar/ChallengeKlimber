using DevelopmentChallenge.Data.Enums;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Triangulo : FormaBase
    {
        public Triangulo(decimal ancho) : base((int)Shapes.Triangle, ancho)
        {
            NombreSingular = Languages.strings.Triangle;
            NombrePlural = Languages.strings.Triangles;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * base.Lado * base.Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return base.Lado * 3;
        }
    }
}
