namespace StortfordArchers.Models
{
    public class MailSettingsOptions
    {
        public const string MailSettings = "MailSettings";
        public string Mail { get; set; }
        public string ToAddress { get; set; }
        public string BCCMailAddress { get; set; }
        public string CCMailAddress { get; set; }
        public string Password { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }


    }
}
