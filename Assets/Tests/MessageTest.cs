using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EPILOG.Tests
{
	public class MessageTests
	{
		private static TestClass _testClass = new TestClass();

        
#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/All")]
#endif
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

#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/PrintMessageTest")]
#endif
		public static void PrintMessageTest()
		{
			RunTests(LogType.Log);
		}

#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/ErrorMessageTest")]
#endif
		public static void ErrorMessageTest()
		{
			RunTests(LogType.Error);
		}

#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/WarningMessageTest")]
#endif		
		public static void WarningMessageTest()
		{
			RunTests(LogType.Warning);
		}

#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/ExceptionMessageTest")]
#endif		
		public static void ExceptionMessageTest()
		{
			RunTests(LogType.Exception);
		}

#if UNITY_EDITOR
		[MenuItem("Window/EPILOG/Tests/AssertMessageTest")]
#endif
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
