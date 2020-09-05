#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace EPILOG.Tests
{
    public class EmojiTest
    {
        #if UNITY_EDITOR
        [MenuItem("Window/EPILOG/Tests/EmojiTest")]
        #endif
        public static void EmojiTestRun()
        {
            Epilog.Emoji.Shrug();
            Epilog.Emoji.FlipTable();
            Epilog.Emoji.UnFlipTable();
            Epilog.Emoji.FlipWork();
            Epilog.Emoji.FlipSomebody();
            Epilog.Emoji.Butterfly();
            Epilog.Emoji.Facepalm();
            Epilog.Emoji.AssaultRiffle();
            Epilog.Emoji.SniperRiffle();
            Epilog.Emoji.Sad();
            Epilog.Emoji.FU();
            Epilog.Emoji.Hi();
            Epilog.Emoji.Think();
            Epilog.Emoji.SunGlasses();
            Epilog.Emoji.Orly();
            Epilog.Emoji.HowMushIsThe();
            Epilog.Emoji.Wink();
            Epilog.Emoji.Run();
            Epilog.Emoji.Team();
            Epilog.Emoji.Strong();
            Epilog.Emoji.Peace();
            Epilog.Emoji.Disapproval();
            Epilog.Emoji.Sleep();
            Epilog.Emoji.Shocked();
            Epilog.Emoji.NiceBear();
            Epilog.Emoji.Excited();
            Epilog.Emoji.Nooo();
            Epilog.Emoji.Angry();
            Epilog.Emoji.RollingEyes();
            Epilog.Emoji.Bears();
            Epilog.Emoji.Smile();
            Epilog.Emoji.Typing();
            Epilog.Emoji.Dog();
            Epilog.Emoji.Cat();
            Epilog.Emoji.ScepticBear();
            Epilog.Emoji.Bear();
            Epilog.Emoji.Surprised();
        }
    }
}
