using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace JustTicket.Engining
{
    public class ExpressionHelper
    {
        public static T GetResult<T>(string expression)
        {
            expression = "return " + expression +";";
            CompilerParameters param = new CompilerParameters();
            param.GenerateInMemory = true;
            string s = typeof(T).Name;
            string str = string.Format("using System; class {0}{{public {3} {1}(){{{2}}}}}","MyClass","GetBool",expression,s);
            CompilerResults cr = new CSharpCodeProvider().CompileAssemblyFromSource(param, str);
            if(cr.Errors.Count>0)
            {
                string msg = "Expressin(\"" + expression + "\"):\n";
                foreach (var err in cr.Errors)
                    msg += err.ToString() + "\n";
                Console.WriteLine(msg);
            }

            object instance = cr.CompiledAssembly.CreateInstance("MyClass");
            MethodInfo method = instance.GetType().GetMethod("GetBool");

            return (T)method.Invoke(instance, null);
        }

        
    }
}
