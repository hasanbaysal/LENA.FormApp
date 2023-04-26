using LENA.FormApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Common.ResponseModels
{

    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        public Response(ResponseType responseType, string message) : this(responseType)
        {
            Message = message;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }


    }

   

  
}
