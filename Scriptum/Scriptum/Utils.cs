using static System.Net.WebRequestMethods;

namespace Scriptum
{
    public class Utils
    {

        public static string SelectType(int? tipo)
        {
            Console.WriteLine(tipo);
            switch (tipo)
            {
                case 0:
                    return "Libros";
                case 1:
                    return "Cómics";
                case 2:
                    return "Revistas";
                case 3:
                    return "Artículos";
                default:
                    return "Todos los tipos";
            }
          
        }

        public static string SelectSearchFilters(string idGenere)
        {
            switch (idGenere)
            {
                case "roma":
                    return "Romance";
                case "aven":
                    return "Aventura";
                case "cien":
                    return "Ciencia ficción";
                case "cienc":
                    return "Ciencia";
                case "dram":
                    return "Drama";
                case "fant":
                    return "Fantasía";
                case "filo":
                    return "Filosofía";
                case "hist":
                    return "Historia";
                case "susp":
                    return "Suspense";
                case "terr":
                    return "Terror";
                default:
                    return "Todos los géneros";
            }
        }
    }
}
