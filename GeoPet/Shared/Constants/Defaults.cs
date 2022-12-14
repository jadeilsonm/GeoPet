namespace GeoPetAPI.Shared.Constants
{
    public static class Defaults
    {
        public const string KEY = "p9ODSdsIb0cLoIQk8Kq0H0x3qYCm6eZq";
        public const int EXPIRATION_TIME = 30;
        public const string CONNECTION_SGRING = @"
                Server=127.0.0.1;
                Database=GeoPet;
                User=sa;
                Password=Password12!;
                TrustServerCertificate=True
            ";
        public const string URL_BASE_VIA_CEP = "http://viacep.com.br/";
        public const string URL_BASE_NOMINATION = "https://nominatim.openstreetmap.org/";
    }
}
