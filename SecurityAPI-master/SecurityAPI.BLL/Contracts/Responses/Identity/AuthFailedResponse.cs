using System.Collections.Generic;

namespace SecurityAPI.BLL.Contracts.Responses.Identity
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}