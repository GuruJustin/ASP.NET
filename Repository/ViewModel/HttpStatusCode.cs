using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public enum HttpStatusCode
    {
        OK=200,
        Created=201,
        Accepted=202,
        BadRequest=400,
        Forbidden=403,
        ServerError=500,
        ServiceNotAvailable=501,
        UnAuthorized=401,
        NotFound=404,
        MethodNotAllowed=405
    }
}
