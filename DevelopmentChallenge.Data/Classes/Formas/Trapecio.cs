using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Trapecio : FormaBase
    {
        private decimal Tope { get; set; }
        private decimal Alto { get; set; }
        private decimal LadoA { get; set; }
        private decimal LadoB { get; set; }

        public Trapecio(decimal ancho, decimal anchoMenor, decimal alto, decimal ladoA, decimal ladoB) : base((int)Shapes.Trapezoid, ancho)
        {
            Tope = anchoMenor;
            Alto = alto;
            LadoA = ladoA;
            LadoB = ladoB;
            NombreSingular = Languages.strings.Trapezoid;
            NombrePlural = Languages.strings.Trapezoids;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)((base.Lado + Tope) / 2) * Alto);
        }

        public override decimal CalcularPerimetro()
        {
            return base.Lado + Tope + LadoA + LadoB;
        }
    }
}
