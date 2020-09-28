using System;

namespace Constants
{
    [Serializable]
    public class Messages
    {
        public const string InvalidInput = "Geçersiz girdi değeri";
        public const string NullParamether = "Methoda gönderilen değer boş olamaz!";

        public static string MoveDirectionCanNotBeEmpty { get; set; }
    }
}
