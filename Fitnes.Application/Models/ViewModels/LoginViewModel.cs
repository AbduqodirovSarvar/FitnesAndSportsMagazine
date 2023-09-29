using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class LoginViewModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public UserViewModel User { get; set; } = null!;
    }
}
