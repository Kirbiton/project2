using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

public class Program
{
    public static void Main()
    {


        string code = @"
            using System;
            public class MyClass
            {
                public void MyMethod()
                {
                    Console.WriteLine(""Hello, хуй executed from a string!"");
                }
            }";

        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        CompilerParameters parameters = new CompilerParameters();
        parameters.GenerateInMemory = true;
        CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
        Assembly assembly = results.CompiledAssembly;
        Type myClassType = assembly.GetType("MyClass");
        dynamic myClassInstance = Activator.CreateInstance(myClassType);
        myClassType.GetMethod("MyMethod").Invoke(myClassInstance, null);
    }
}