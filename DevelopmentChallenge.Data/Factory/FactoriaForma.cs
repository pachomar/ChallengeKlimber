using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Factory
{
    public class FactoriaForma
    {
        public static FormaBase CrearForma(int tipo, decimal ancho, decimal alto = 0, decimal ladoA = 0, decimal ladoB = 0, decimal anchoB = 0)
        {
            switch (tipo) {
                case (int)Shapes.Square:
                    return new Cuadrado(ancho);
                case (int)Shapes.Triangle:
                    return new Triangulo(ancho);
                case (int)Shapes.Circle:
                    return new Circulo(ancho);
                case (int)Shapes.Rectangle:
                    return new Rectangulo(ancho, alto);
                case (int)Shapes.Trapezoid:
                    return new Trapecio(ancho, anchoB, alto, ladoA, ladoB);
                default:
                    return null;
            }

        }
    }
}
