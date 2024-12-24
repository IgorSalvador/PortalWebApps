using PortalWebApps.WebApp.Database;
using System.Net;
using System.Net.Mail;

namespace PortalWebApps.WebApp.Models
{
    public class Email
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        private string _strFrom { get; set; } = string.Empty;
        private string _usernameSMTP { get; set; } = string.Empty;
        private string _passwordSMTP { get; set; } = string.Empty;
        private int _intPorta { get; set; } = 0;
        private bool _isSSL { get; set; } = false;
        private bool _useDefaultCredentials { get; set; } = false;
        private string _baseApplicationUri { get; set; } = string.Empty;

        public Email(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            Initialize();
        }

        public void Initialize()
        {
            try
            {
                var systemSettings = _context.SystemSettings.ToList();

                if (systemSettings == null || !systemSettings.Any())
                    throw new Exception("Erro ao carregar as configurações de sistema!");

                _strFrom = systemSettings.FirstOrDefault(x => x.Id == 4)!.Value;
                _usernameSMTP = systemSettings.FirstOrDefault(x => x.Id == 1)!.Value;
                _passwordSMTP = systemSettings.FirstOrDefault(x => x.Id == 5)!.Value;
                _intPorta = int.Parse(systemSettings.FirstOrDefault(x => x.Id == 2)!.Value);
                _isSSL = bool.Parse(systemSettings.FirstOrDefault(x => x.Id == 3)!.Value);
                _useDefaultCredentials = true;
                _baseApplicationUri = systemSettings.FirstOrDefault(x => x.Id == 6)!.Value;
            }
            catch
            {
                throw;
            }
        }

        public string SendEmail(List<string> listEmails, string subject, string body, MailPriority mailPriority, List<Attachment> Files = null)
        {
            string msgResult = string.Empty;

            try
            {
                MailMessage objMailMessage = new MailMessage();

                for (int i = 0; i < listEmails.Count; i++)
                {
                    objMailMessage.To.Add(listEmails[i]);
                }

                if (Files != null)
                {
                    foreach (var oAttch in Files)
                    {
                        objMailMessage.Attachments.Add(oAttch);
                    }
                }

                objMailMessage.From = new MailAddress(this._strFrom, "WebApps Portal");
                objMailMessage.Subject = subject;
                objMailMessage.Body = body;
                objMailMessage.Priority = mailPriority;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = this._usernameSMTP;
                smtp.Port = this._intPorta;
                smtp.EnableSsl = this._isSSL;
                smtp.Credentials = new System.Net.NetworkCredential(this._strFrom, this._passwordSMTP);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.Send(objMailMessage);

                msgResult = "Sucesso! Envio de e-mail realizado.";
            }
            catch (Exception ex)
            {
                msgResult = ex.ToString();
            }

            return msgResult;
        }

        public string SendEmail(List<string> listEmails, List<string> listEmailsCc, string subject, string body, MailPriority mailPriority, List<Attachment> Files = null)
        {
            string msgResult = string.Empty;

            try
            {
                MailMessage objMailMessage = new MailMessage();

                for (int i = 0; i < listEmails.Count; i++)
                {
                    objMailMessage.To.Add(listEmails[i]);
                }

                for (int i = 0; i < listEmailsCc.Count; i++)
                {
                    objMailMessage.CC.Add(listEmailsCc[i]);
                }

                if (Files != null)
                {
                    foreach (var oAttch in Files)
                    {
                        objMailMessage.Attachments.Add(oAttch);
                    }
                }

                objMailMessage.From = new MailAddress(this._strFrom, "WebApps Portal");
                objMailMessage.Subject = subject;
                objMailMessage.Body = body;
                objMailMessage.Priority = mailPriority;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = this._usernameSMTP;
                smtp.Port = this._intPorta;
                smtp.EnableSsl = this._isSSL;
                smtp.Credentials = new System.Net.NetworkCredential(this._strFrom, this._passwordSMTP);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.Send(objMailMessage);

                msgResult = "Sucesso! Envio de e-mail realizado.";
            }
            catch (Exception ex)
            {
                msgResult = ex.ToString();
            }

            return msgResult;
        }

        public string SendEmail(List<string> listEmails, string subject, AlternateView body, MailPriority mailPriority, List<Attachment> Files = null)
        {
            string msgResult = string.Empty;

            try
            {
                MailMessage objMailMessage = new MailMessage();

                for (int i = 0; i < listEmails.Count; i++)
                {
                    objMailMessage.To.Add(listEmails[i]);
                }

                if (Files != null)
                {
                    foreach (var oAttch in Files)
                    {
                        objMailMessage.Attachments.Add(oAttch);
                    }
                }

                objMailMessage.From = new MailAddress(this._strFrom, "WebApps Portal");
                objMailMessage.Subject = subject;
                objMailMessage.AlternateViews.Add(body);
                objMailMessage.Priority = mailPriority;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = this._usernameSMTP;
                smtp.Port = this._intPorta;
                smtp.EnableSsl = this._isSSL;
                smtp.Credentials = new System.Net.NetworkCredential(this._strFrom, this._passwordSMTP);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.Send(objMailMessage);

                msgResult = "Sucesso! Envio de e-mail realizado.";
            }
            catch (Exception ex)
            {
                msgResult = ex.ToString();
            }

            return msgResult;
        }

        public string SendEmail(List<string> listEmails, List<string> listEmailsCc, string subject, AlternateView body, MailPriority mailPriority, List<Attachment> Files = null)
        {
            string msgResult = string.Empty;

            try
            {
                MailMessage objMailMessage = new MailMessage();

                for (int i = 0; i < listEmails.Count; i++)
                {
                    objMailMessage.To.Add(listEmails[i]);
                }

                for (int i = 0; i < listEmailsCc.Count; i++)
                {
                    objMailMessage.CC.Add(listEmailsCc[i]);
                }

                if (Files != null)
                {
                    foreach (var oAttch in Files)
                    {
                        objMailMessage.Attachments.Add(oAttch);
                    }
                }

                objMailMessage.From = new MailAddress(this._strFrom, "WebApps Portal");
                objMailMessage.Subject = subject;
                objMailMessage.AlternateViews.Add(body);
                objMailMessage.Priority = mailPriority;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = this._usernameSMTP;
                smtp.Port = this._intPorta;
                smtp.EnableSsl = this._isSSL;
                smtp.Credentials = new System.Net.NetworkCredential(this._strFrom, this._passwordSMTP);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.Send(objMailMessage);

                msgResult = "Sucesso! Envio de e-mail realizado.";
            }
            catch (Exception ex)
            {
                msgResult = ex.ToString();
            }

            return msgResult;
        }
    }
}
