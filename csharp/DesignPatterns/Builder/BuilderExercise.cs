using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Builder
{
    public class Code
    {
        public string Name, Type;
        public List<Code> codes = new List<Code>();
        private const int INDENT_SIZE = 1;

        public Code()
        {

        }

        public Code(string name, string type)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(Name));
            Type = type ?? throw new ArgumentNullException(paramName: nameof(Type));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Type))
            {
                var i = new string(' ', INDENT_SIZE * indent);
            
                sb.AppendLine($"{i} public {Type} {Name};");
            }

            foreach (var c in codes)
            {
                sb.Append(c.ToStringImpl(indent + 1));
            }

            
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    public class CodeBuilder
    {
        public string ClassName;
        public Code code = new Code();
        public CodeBuilder(string className)
        {
            this.ClassName = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            var c = new Code(name, type);
            code.codes.Add(c);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            sb.Append(code.ToString());
            sb.AppendLine("}");
            return sb.ToString();

        }
    }

}
