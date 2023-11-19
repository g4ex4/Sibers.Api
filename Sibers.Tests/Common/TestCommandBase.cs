using Sibers.BLL.Common.Responses;
using Sibers.WebAPI.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Tests.Common
{
    public abstract class TestCommandBase
    {
        protected readonly HttpClient _client;
        protected TestCommandBase()
        {
            var application = new MyWebApplication();
            _client = application.CreateClient();

            var request = new LoginDto()
            {
                UserName = "admin",
                Password = "admin",
                RememberMe = true,
            };
            TestHelper<Response>.MakeRequest(_client, "POST", "api/Auth/login", request);
            
        }
    }
}
