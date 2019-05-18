using System.Threading.Tasks;

namespace IrmandadeNsg.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
