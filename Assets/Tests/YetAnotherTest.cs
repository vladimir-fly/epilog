using System;
using System.Collections.Generic;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using EPILOG;

namespace Another.Tests
{
    public class YetAnotherTest
    {
        #if UNITY_EDITOR
        [MenuItem("Window/EPILOG/Tests/YetAnotherTest")]
        #endif
        public static void YetAnotherTestRun()
        {
            Epilog.Print("Epilog in yet another test", 42, "Hi!", true, 4.2, new Tuple<int,bool>(15, false));
            Epilog.Emoji.Shrug("It's nothing here");
        }
    }
}
