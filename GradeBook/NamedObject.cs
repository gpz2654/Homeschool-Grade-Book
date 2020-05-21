using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class NamedObject // Base class - DRY (Don't Repeat Yourself). Should go into new file
    {
        public NamedObject(string name) //  constructor
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
