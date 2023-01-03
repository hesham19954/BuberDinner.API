using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Exceptions
{
    public class BuberException:Exception
    {
        public string? StatusCode { private set; get; }
        public new IEnumerable<object>? Data { set; get; }

    }
}
