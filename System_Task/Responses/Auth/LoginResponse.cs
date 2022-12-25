namespace System_Task.Responses.Auth
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            Token = string.Empty;
        }
        public string Token { get; set; }
    }
}
