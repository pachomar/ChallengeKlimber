using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<IFormaBase>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            var cuadrados = new List<IFormaBase> { Factory.FactoriaForma.CrearForma((int)Shapes.Square, 5) };
            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var cuadrados = new List<IFormaBase>
            {
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 5),
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 1),
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes Report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var formas = new List<IFormaBase>
            {
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 5),
                Factory.FactoriaForma.CrearForma((int)Shapes.Circle, 3),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 4),
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 2),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 9),
                Factory.FactoriaForma.CrearForma((int)Shapes.Circle, 2.75m),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 4.2m),
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            var formas = new List<IFormaBase>
            {
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 5),
                Factory.FactoriaForma.CrearForma((int)Shapes.Circle, 3),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 4),
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 2),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 9),
                Factory.FactoriaForma.CrearForma((int)Shapes.Circle, 2.75m),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 4.2m),
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaNuevosTiposBilingue()
        {
            var formas = new List<IFormaBase>
            {
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 5),
                Factory.FactoriaForma.CrearForma((int)Shapes.Circle, 3),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 4),
                Factory.FactoriaForma.CrearForma((int)Shapes.Square, 2),
                Factory.FactoriaForma.CrearForma((int)Shapes.Triangle, 9),
                Factory.FactoriaForma.CrearForma((int)Shapes.Rectangle, 2.75m, 1.78m),
                Factory.FactoriaForma.CrearForma((int)Shapes.Trapezoid, 4.2m, 1.93m, 1.54m, 2.01m, 3.11m),
            };

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            var resumenES = FormaGeometrica.Imprimir(formas);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

            var resumenFR = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>1 Círculo | Area 7,07 | Perimetro 9,42 <br/>2 Triángulos | Area 42 | Perimetro 39 <br/>1 Rectángulo | Area 4,9 | Perimetro 9,06 <br/>1 Trapecio | Area 7,05 | Perimetro 10,86 <br/>TOTAL:<br/>7 formas Perimetro 96,34 Area 90,02",
                resumenES);

            Assert.AreEqual(
                "<h1>Rapport sur les Formes</h1>2 Latérales | Zone 29 | Périmètre 28 <br/>1 Cercle | Zone 7,07 | Périmètre 9,42 <br/>2 Triángulos | Zone 42 | Périmètre 39 <br/>1 Rectangle | Zone 4,9 | Périmètre 9,06 <br/>1 Trapèze | Zone 7,05 | Périmètre 10,86 <br/>TOTAL:<br/>7 formes Périmètre 96,34 Zone 90,02",
                resumenFR);

        }
    }
}
