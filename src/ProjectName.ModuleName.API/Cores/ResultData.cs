using System.Collections;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Stu.AspNetCore.Mvc.Implements;
using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc
{
    public class ResultData<T>
    {
        public ResultData()
        {
            StatusCode = HttpStatusCode.OK;
            Error = new SuccessCode();
            Data = default(T);
            Total = 1;
        }

        public ResultData(T dataDefault)
        {
            StatusCode = HttpStatusCode.OK;
            Error = new SuccessCode();
            Data = dataDefault;
            Total = 1;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        public HttpStatusCode StatusCode { get; set; }

        public IErrorCode Error { get; set; }

        public T _data;

        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        private long _total;

        public long Total
        {
            get
            {
                if (_total == 0)
                {
                    if (Data is IList)
                    {
                        _total = (Data as IList).Count;
                    }
                    else if (Data != null)
                    {
                        _total = 1;
                        return _total;
                    }
                }
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        public void CopyFrom<TF>(ResultData<TF> source)
        {
            StatusCode = source.StatusCode;
            Error = source.Error;
            Total = source.Total;
        }
    }
}
