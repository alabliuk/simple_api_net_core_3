using ApiRestCore.Utils;

namespace ApiRestCore.Data
{
    public abstract class Conn
    {
        public static string ConnString { get; private set; }

        public Conn()
        {
            var config = new JsonTools().ReadTokensAppsettings();
            ConnString = config.GetSection("Conn:DB").Value;
        }
    }
}
