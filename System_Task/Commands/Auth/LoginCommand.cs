namespace System_Task.Commands.Auth
{
    public class LoginCommand
    {
        public LoginCommand()
        {
            UserName = string.Empty;
            Password= string.Empty;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
