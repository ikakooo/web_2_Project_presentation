using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebProject_API.Models
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; internal set; }
    }
}
