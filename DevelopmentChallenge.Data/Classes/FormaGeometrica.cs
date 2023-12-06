/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Factory;
using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{

    public class FormaGeometrica
    {
        public static string Imprimir(List<IFormaBase> formas)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>" + Languages.strings.EmptyShapeList + "</h1>");
            }
            else
            {
                sb.Append("<h1>" + Languages.strings.ShapeReportTitle + "</h1>");

                int totalFormas = 0;
                decimal totalAreas = 0;
                decimal totalPermietros = 0;

                foreach (int shape in Enum.GetValues(typeof(Shapes)))
                {
                    IEnumerable<IFormaBase> selected = formas.Where(x => x.Tipo == shape);
                    if (selected.Count() > 0)
                    {
                        var sumaAreas = selected.Sum(x => x.CalcularArea());
                        var sumaPerimetros = selected.Sum(x => x.CalcularPerimetro());

                        sb.Append(ObtenerLinea(selected.Count(), sumaAreas, sumaPerimetros, shape));

                        totalFormas += selected.Count();
                        totalAreas += sumaAreas;
                        totalPermietros += sumaPerimetros;
                    }
                }
                
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(totalFormas + " " + Languages.strings.Shapes + " ");
                sb.Append(Languages.strings.Perimeter + " " + totalPermietros.ToString("#.##") + " ");
                sb.Append(Languages.strings.Area + " " + totalAreas.ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            if (cantidad > 0)
            {
                return String.Format(Languages.strings.ResultLine, cantidad, TraducirForma(cantidad, tipo), area, perimetro);
            }

            return string.Empty;
        }

        private static string TraducirForma(int cantidad, int tipo)
        {
            return FactoriaForma.CrearForma(tipo, 0).ObtenerNombre(cantidad == 1);
        }
    }
}
