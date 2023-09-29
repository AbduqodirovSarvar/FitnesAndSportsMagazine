namespace Fitnes.Application.Interfaces
{
    public interface IMailSender
    {
        Task SendMessage(string emailAddress, string message);
    }
}
