using BuberDinner.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Exceptions
{
    public class BuberException:Exception
    {
        public int StatusCode { private set; get; }
        public new IEnumerable<object>? Data { set; get; }

        public BuberException(ErrorCodes errorCodes ,int statusCode) : base(/*TraceLinkErrors.ResourceManager.GetString(errorCodes.ToString())*/)
        {
            int EnumIntValue = (int)errorCodes;
            this.StatusCode = statusCode;
            // string stringifyInt = EnumIntValue.ToString();
            //  this.StatusCode = BuberDinnerResponses.ResourceManager.GetString(stringifyInt);
        }

    }
}
