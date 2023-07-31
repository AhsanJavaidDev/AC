using System.Threading.Tasks;

namespace AcmeCorp.Domain.Services.Mail
{
    public interface IMailService
    {
        Task Send(MailMessage message);
    }
}
