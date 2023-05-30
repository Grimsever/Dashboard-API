namespace SecurityAPI.BLL.Contracts.Responses.Identity
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        
        public int UserId { get; set; }
        
        public string ExpirationDate { get; set; }
    }
}