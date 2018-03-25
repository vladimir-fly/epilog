using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

namespace EPILOG.Tests
{
	public class MessageTests
	{
		private static TestClass _testClass = new TestClass();

		[MenuItem("Window/EPILOG/Tests/All")]
        public static void RunAll()
        {
			Epilog.Print("Message tests started. \n -----------------------------");

			PrintMessageTest();
			ErrorMessageTest();
			WarningMessageTest();
			ExceptionMessageTest();
			AssertMessageTest();

			Epilog.Print("Message tests complete. \n -----------------------------");
        }

		[MenuItem("Window/EPILOG/Tests/PrintMessageTest")]
		public static void PrintMessageTest()
		{
			RunTests(LogType.Log);
		}

		[MenuItem("Window/EPILOG/Tests/ErrorMessageTest")]
		public static void ErrorMessageTest()
		{
			RunTests(LogType.Error);
		}

		[MenuItem("Window/EPILOG/Tests/WarningMessageTest")]
		public static void WarningMessageTest()
		{
			RunTests(LogType.Warning);
		}

		[MenuItem("Window/EPILOG/Tests/ExceptionMessageTest")]
		public static void ExceptionMessageTest()
		{
			RunTests(LogType.Exception);
		}

		[MenuItem("Window/EPILOG/Tests/AssertMessageTest")]
		public static void AssertMessageTest()
		{
			RunTests(LogType.Assert);
		}

		private static void RunTests(LogType logType)
		{
			_testClass.SingleArgPrintTest(logType, "single arg");
			_testClass.MultiplyArgsPrintTest(logType, new Vector3(.3f, 6, .2f), "hello", false, 4.5f);
			_testClass.ArgsCollectionPrintTest(logType, new List<string>() {"first", "second", "third"});
		}
    }
}