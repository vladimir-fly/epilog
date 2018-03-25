using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using EPILOG;

namespace Another.Tests
{
    public class YetAnotherTest
    {
        [MenuItem("Window/EPILOG/Tests/YetAnotherTest")]
        public static void YetAnotherTestRun()
        {
            Epilog.Print("Epilog in yet another test", 42, "Hi!", true, 4.2, new Tuple<int,bool>(15, false));
            Epilog.Shrug("It's nothing here");
        }
    }
}