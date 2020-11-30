using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ViewModel
{
    public class JsonModel
    {
        public JsonModel(Object _data, string _Message, int _StatusCode, string _AppError)
        {
            this.Data = _data;
            this.Message = _Message;
            this.StatusCode = _StatusCode;
            this.AppError = _AppError;

        }

        public Object Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string AppError { get; set; }

    }
}
