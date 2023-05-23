using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trinca.Churras.Application.Core
{
    public class ErrorResponse
    {

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
