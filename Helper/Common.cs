using System;
using System.Collections.Generic;
using System.Linq;

namespace Helper
{

    [Serializable]
    public class GenericResponse<T> : ResponseBase
    {

        public GenericResponse()
            : base()
        {
        }

        public T Value
        {
            get;
            set;
        }
    }
    public class Result
    {
        private String errorCode;
        public String ErrorCode
        {
            get
            {
                return errorCode;
            }
            set
            {
                errorCode = value;
            }
        }
        public String ErrorMessage { get; set; }

      
    }
    [Serializable]
    public class ResponseBase
    {
        public ResponseBase()
        {
        }

        List<Result> _results;

        public virtual List<Result> Results
        {
            get
            {
                if (_results == null)
                    _results = new List<Result>();
                return _results;
            }
            set
            {
                _results = value;
            }
        }



        public virtual bool Success
        {
            get
            {
                return !Results.Any();
            }
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }


    }
}
