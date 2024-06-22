using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderExercise
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Field(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class CodeBuilderSol2
    {
        public string ClassName { get; }
        public List<Field> Fields { get; } = new List<Field>();
        private const int IndentSize = 2;

        public CodeBuilderSol2(string className)
        {
            ClassName = className;
        }

        public CodeBuilderSol2 AddField(string name, string type)
        {
            Fields.Add(new Field(name, type));
            return this;
        }

        public override string ToString()
        {
            var indent = new string(' ', IndentSize);
            string result = $"public class {ClassName}\n{{\n";
            foreach (var field in Fields)
            {
                result += $"{indent}public {field.Type} {field.Name};\n";
            }
            result += "}";
            return result;
        }
    }
}
