using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public sealed class Profile
    {
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public int NumberOfCredentials { get; set; }
    }
}