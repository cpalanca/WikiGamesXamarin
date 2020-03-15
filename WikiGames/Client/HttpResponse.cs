using System;
using RestSharp;
namespace WikiGames.Client
{
    public class HttpResponse<T>
    {
        public T Result { get; set; }
        public StatusResponse Status { get; set; }
        public IRestResponse Response { get; set; }

    }
}
