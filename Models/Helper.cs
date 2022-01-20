using System;
using System.Net.Mail;

namespace StortfordArchers.Models
{
    public class Helper
    {
        private string _fromAddress;
        private string _toAddress;
        private string _emailServer;
        private int _emailPort;
        private string _emailCCAddress;
        private string _emailBCCAddress;
        public Helper(string fromAddress, string emailServer, int emailPort, string emailCCAddress, string emailBCCAddress, string toAddress)
        {
            _fromAddress = fromAddress;
            _emailServer = emailServer; 
            _emailPort = emailPort; 
            _emailCCAddress = emailCCAddress;   
            _emailBCCAddress = emailBCCAddress;
            _toAddress = toAddress;
            
        }
        public Helper(MailSettingsOptions emailOptions)
        {
            _fromAddress = emailOptions.Mail; ///fromAddress;
            _emailServer = emailOptions.Host;
            _emailPort = emailOptions.Port;
            _emailCCAddress = emailOptions.CCMailAddress;
            _emailBCCAddress = emailOptions.BCCMailAddress;
            _toAddress = emailOptions.ToAddress;

        }

        /// <summary>
        /// Sends the requested email.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="emailBodyText"></param>
        public string SendEmail (string subject, string emailBodyText, string customerEmail)
        {
            SmtpClient client = null;
            try
            {
                // Extract all of the required settings
                string fromMailAddress = _fromAddress;
                string emailServer = _emailServer;
                int portNumber = _emailPort;

                MailAddress fromMail = new MailAddress(fromMailAddress);
                MailAddress toMail = new MailAddress(_toAddress);

                MailMessage msgDetails = new MailMessage(fromMail, toMail);

                #region Add the CC mail addresses
                if (string.Empty != customerEmail)
                    msgDetails.CC.Add(customerEmail);

                string ccEmail = _emailCCAddress;
                if (ccEmail.Contains(";"))
                {
                    string[] ccMailAddresses = ccEmail.Split(';');
                    foreach (string c in ccMailAddresses)
                        msgDetails.CC.Add(c);
                }
                else if (string.Empty != ccEmail)
                    msgDetails.CC.Add(ccEmail);
                #endregion Add the CC mail addresses

                #region Add the BCC mail addresses
                string bccEmail = _emailBCCAddress;
                if (bccEmail.Contains(";"))
                {
                    string[] bccMailAddresses = bccEmail.Split(';');
                    foreach (string b in bccMailAddresses)
                        msgDetails.Bcc.Add(b);
                }
                else if (string.Empty != bccEmail)
                    msgDetails.Bcc.Add(bccEmail);
                #endregion Add the BCC mail addresses

                msgDetails.Body = emailBodyText;
                msgDetails.IsBodyHtml = true;
                msgDetails.Subject = subject;

                // Send the email.
                client = new SmtpClient(emailServer, portNumber)
                {
                   // EnableSsl = Convert.ToBoolean(AppSetting("Email.Encryption")),
                    Credentials = new System.Net.NetworkCredential("info@rsstudios.co.uk", "n[lK!irazwdqgpxymejAsukf4h3c")
                };
                client.Send(msgDetails);
            }
            catch (Exception ex)
            {
                //throw new ApplicationException("Email not sent.  Message: " + ex.Message + ".  InnerEx: " + ex.InnerException);
                return "Email not sent.  Message: " + ex.Message + ".  InnerEx: " + ex.InnerException;
            }
            finally
            {
                if (null != client)
                    client = null;
            }

            return string.Empty;
        }
    }
}
