﻿#if DNXCORE50
#define DNXCORE
#endif

using System;
using System.Reflection;
using System.Text;
using static System.Console;

namespace TypeView
{
    public class Program
    {
        static StringBuilder OutputText = new StringBuilder();

        public static void Main()
        {
            // modify this line to retrieve details of any other data type
            Type t = typeof(double);

            AnalyzeType(t);
            WriteLine($"Analysis of type {t.Name}");
            WriteLine(OutputText.ToString());

            ReadLine();

        }

        static void AnalyzeType(Type t)
        {
            TypeInfo typeInfo = t.GetTypeInfo();
            AddToOutput($"Type Name: {t.Name}");
            AddToOutput($"Full Name: {t.FullName}");
            AddToOutput($"Namespace: {t.Namespace}");

            Type tBase = typeInfo.BaseType;

            if (tBase != null)
            {
                AddToOutput($"Base Type: {tBase.Name}");
            }


            AddToOutput("\npublic members:");
            foreach (MemberInfo member in t.GetMembers())
            {
#if DNXCORE
                AddToOutput($"{member.DeclaringType} {member.Name}");
#else
                AddToOutput($"{member.DeclaringType} {member.MemberType} {member.Name}");
#endif

            }
        }

        static void AddToOutput(string Text)
        {
            OutputText.Append($"\n {Text}");
        }


    }
}