using System.Collections.Generic;
using Newtonsoft.Json;

namespace SaaramshaApps.Common
{
    public static class ResponseUtility
    {
        private const string Success       = "Request was successfull";

        private const string UnSuccessfull = "Request was unsuccessfull";

        public static Response CreateResponse<T>(T response,bool isSuccessful=true)
        {
            return new Response
            {
                Message = isSuccessful ? Success : UnSuccessfull,
                Success=isSuccessful,
                Result=!EqualityComparer<T>.Default.Equals(response,default(T))? JsonConvert.SerializeObject(response):null
            };
        }
    }
}