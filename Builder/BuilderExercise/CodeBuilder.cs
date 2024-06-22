using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderExercise
{
    public class CodeBuilder
    {
        public string ClassName { get; set; }
        public List<(string name, string type)> Fields = new List<(string name, string type)>();
        private const int indentSize = 2; 

        public CodeBuilder(string className) 
        {
            this.ClassName = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            Fields.Add((name, type));
            return this;
        }
        private string ToStringImp1()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            var i = new string(' ', indentSize);
            foreach (var field in Fields)
            {
                sb.AppendLine($"{i}public {field.type} {field.name};");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImp1();
        }
    }
}
