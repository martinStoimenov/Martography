using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IEmailService
    {
        Task<bool> Send(string from, string subject, string message, string name, string to = "martin.hj15@gmail.com");
        Task<bool> CreateContact(string email, string name);
    }
}
