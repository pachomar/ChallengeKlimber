using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Rectangulo: FormaBase
    {
        private decimal Alto { get; set; }

        public Rectangulo(decimal ancho, decimal alto) : base((int)Shapes.Rectangle, ancho)
        {
            Alto = alto;
            NombreSingular = Languages.strings.Rectangle;
            NombrePlural = Languages.strings.Rectangles;
        }

        public override decimal CalcularArea()
        {
            return base.Lado * Alto;
        }

        public override decimal CalcularPerimetro()
        {
            return base.Lado * 2 + Alto * 2;
        }
    }
}
