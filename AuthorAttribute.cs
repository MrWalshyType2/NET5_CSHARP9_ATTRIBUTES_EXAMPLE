using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = true) // multiuse attribute
    ]
    public class AuthorAttribute : System.Attribute
    {
        private string name;
        public double version;

        public string Name { get => name; set => name = value; }

        public AuthorAttribute(string name)
        {
            Name = name;
            version = 1.0;
        }
    }
}
