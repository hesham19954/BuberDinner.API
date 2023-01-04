using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.ENUM
{
    public enum ErrorCodes
    {
        NotFound = 0,
        Unauthorized = 1,
        InternalServerError = 2,
        InvalidEncodingType = 3,
        InvalidObjectIdentifierName = 4,
        ConnectionTimeOut = 5,
        Succeeded = 6,

        InvalidTenantId = 7,
        InvalidSize = 8,
        InvalidGTIN = 9,
    }
}
