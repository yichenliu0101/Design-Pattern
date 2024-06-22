using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritanceWithRecursion
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{nameof(Name)}:{Name}, {nameof(Position)}:{Position}";
        }
    }
}
