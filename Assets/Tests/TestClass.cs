using System;
using System.Collections.Generic;

using UnityEngine;

namespace EPILOG.Tests
{
    public class TestClass
    {
        public void SingleArgPrintTest(LogType logType, object arg)
        {
            Epilog.Print(logType, "Generic print single arg test", arg);
        }

        public void MultiplyArgsPrintTest(LogType logType, object arg1, string arg2, bool arg3, float arg4)
        {
            Epilog.Print(logType, "Generic print multiply args test", arg1, arg2, arg3, arg4);
        }

        public void ArgsCollectionPrintTest(LogType logType, IEnumerable<object> args)
        {
            Epilog.Print(logType, "Generic print args collection test", args);
        }
    }
}
