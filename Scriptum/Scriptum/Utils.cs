using static System.Net.WebRequestMethods;

namespace Scriptum
{
    public class Utils
    {
        public static string FillEmptyImageUrl(string url)
        {
            if (url == null)
            {
                url = "https://res.cloudinary.com/dfd0scyd8/image/upload/v1771443710/fprtspu1qmmwsv3edqf1.png";
            }
            return url;
            
        }

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
