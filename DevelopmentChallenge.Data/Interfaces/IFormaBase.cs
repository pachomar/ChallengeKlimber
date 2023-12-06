namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaBase
    {
        decimal Lado { get; set; }
        int Tipo { get; set; }
        string NombreSingular { get; set; }
        string NombrePlural { get; set; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string ObtenerNombre(bool singular);
    }
}
