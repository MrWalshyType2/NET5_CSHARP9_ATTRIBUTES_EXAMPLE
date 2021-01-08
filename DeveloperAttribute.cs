using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    class DeveloperAttribute : System.Attribute
    {
        private string name;
        private string level;
        private bool reviewed;

        // Two required params
        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }

        // Name Property, read-only
        public virtual string Name
        {
            get { return name; }
        }

        // Level Property, read-only
        public virtual string Level
        {
            get { return level; }
        }

        // Reviewed Property, read/write
        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }
}
