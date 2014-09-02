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
        /// <summary>
        /// 动态传入表达式字符串，返回结果
        /// 适用于bool,字符串,int等类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static T GetResult<T>(string expression)
        {
            expression = "return " + expression +";";
            CompilerParameters param = new CompilerParameters();
            param.GenerateInMemory = true;
            string s = typeof(T).Name;
            string str = string.Format("using System; class {0}{{public {3} {1}(){{{2}}}}}", "MyClass", "MethodName", expression, s);
            CompilerResults cr = new CSharpCodeProvider().CompileAssemblyFromSource(param, str);
            if(cr.Errors.Count>0)
            {
                string msg = "Expressin(\"" + expression + "\"):\n";
                foreach (var err in cr.Errors)
                    msg += err.ToString() + "\n";
                Console.WriteLine(msg);
            }

            object instance = cr.CompiledAssembly.CreateInstance("MyClass");
            MethodInfo method = instance.GetType().GetMethod("MethodName");

            return (T)method.Invoke(instance, null);
        }
    }
}
