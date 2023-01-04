using BuberDinner.Domain.ENUM;

namespace BuberDinner.Domain.Entities
{
    public class Error
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public Error()
        {

        }
        public Error(ErrorCodes errorCodes)
        {
           // Message = TraceLinkErrors.ResourceManager.GetString(errorCodes.ToString());
           Message= errorCodes.ToString();
            StatusCode = (int)errorCodes;
           // string stringifyInt = EnumIntValue.ToString();
            //StatusCode = Convert.ToInt32(TracLinkResponses.ResourceManager.GetString(stringifyInt));
        }


        public Error(ErrorCodes errorCodes, string message)
        {
            Message = message;
            StatusCode = (int)errorCodes;
            //string stringifyInt = EnumIntValue.ToString();
            //StatusCode = Convert.ToInt32(TracLinkResponses.ResourceManager.GetString(stringifyInt));
        }
    }
}
