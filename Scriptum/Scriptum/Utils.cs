using static System.Net.WebRequestMethods;

namespace Scriptum
{
    public class Utils
    {

        public static string SelectSearchFilters(string idGenere)
        {
            switch (idGenere)
            {
                case "Rom":
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
