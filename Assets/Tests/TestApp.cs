using UnityEngine;
using UnityEngine.UI;

namespace EPILOG.Tests
{
	public class TestApp : MonoBehaviour 
	{
		[SerializeField] private Button _runAllTests;
		[SerializeField] private Button _printMessagetTest;
		[SerializeField] private Button _errorMessageTest;
		[SerializeField] private Button _warningMessageTest;
		[SerializeField] private Button _exceptionMessageTest;
		[SerializeField] private Button _assertMessageTest;
		[SerializeField] private Button _yetAnotherTest;

		private void Start()
		{
			_runAllTests.onClick.AddListener(() => MessageTests.RunAll());
			_printMessagetTest.onClick.AddListener(() => MessageTests.PrintMessageTest());
	  		_errorMessageTest.onClick.AddListener(() => MessageTests.ErrorMessageTest());
			_warningMessageTest.onClick.AddListener(() => MessageTests.WarningMessageTest());
			_exceptionMessageTest.onClick.AddListener(() => MessageTests.ExceptionMessageTest());
			_assertMessageTest.onClick.AddListener(() => MessageTests.AssertMessageTest());
			_yetAnotherTest.onClick.AddListener(() => Another.Tests.YetAnotherTest.YetAnotherTestRun());
		}
	}
}