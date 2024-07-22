namespace Supplychain_Core.Helper
{
    public class JWTSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Duration { get; set; }
    }
}
