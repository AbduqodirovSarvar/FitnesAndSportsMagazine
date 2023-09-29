namespace Fitnes.Application.Models.ViewModels
{
    public class LoginViewModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public UserViewModel User { get; set; } = null!;
    }
}
