namespace SecurityAPI.BLL.Contracts.Requests.Identity
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}