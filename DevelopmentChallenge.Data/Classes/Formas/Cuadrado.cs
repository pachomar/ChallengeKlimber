using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Cuadrado : FormaBase
    {
        public Cuadrado(decimal ancho) : base((int)Shapes.Square, ancho)
        {

            NombreSingular = Languages.strings.Square;
            NombrePlural = Languages.strings.Squares;
        }

        public override decimal CalcularArea()
        {
            return base.Lado * base.Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return base.Lado * 4;
        }
    }
}
