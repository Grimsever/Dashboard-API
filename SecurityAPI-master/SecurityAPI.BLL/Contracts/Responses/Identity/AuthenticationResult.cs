using System.Collections.Generic;

namespace SecurityAPI.BLL.Contracts.Responses.Identity
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        
        public int UserId { get; set; }
        
        public string ExpirationDate { get; set; }
        
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}