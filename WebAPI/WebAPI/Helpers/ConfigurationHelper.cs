using System.Configuration;

namespace WebAPI.Helpers
{
    public class ConfigurationHelper
    {

        public static string ServiceUrl = "https://api.dropboxapi.com/2";
        public static string ContentServiceUrl = "https://content.dropboxapi.com/2";
        public static string AuthorizationToken = "Bearer sl.BV02ZWe1Bkb2wRXtBkeu_NT6Co3aXBJ8Dl_4Z8L4LhUum-KVHmU1p0cPZWWLWmHqzr56hyNP8Rk-HhwY6RhoXJAGY1mazSK3oxss7sjtG2RsN-vXoPwh47n_IToxBAmWyoHGAY1MQl-A";
        public static string DefaultFilePath = "";

        /* public static string ServiceUrl => ConfigurationManager.AppSettings["serviceUrl"];
         public static string ContentServiceUrl => ConfigurationManager.AppSettings["contentServiceUrl"];
         public static string AuthorizationToken => ConfigurationManager.AppSettings["token"];
         public static string DefaultFilePath => ConfigurationManager.AppSettings["defaultFilePath"];*/

    }
}
