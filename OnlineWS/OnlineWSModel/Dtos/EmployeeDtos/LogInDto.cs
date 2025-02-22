using BaseLib.Model;

namespace OnlineWSModel.Dtos.EmployeeDtos
{
    public class LogInDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
