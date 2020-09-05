using System;
using System.Runtime.Serialization;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EPILOG
{
    [Serializable]
    public class Style
    {
        public int FontSize { get; private set; }
        public string ClassColor { get; private set; }
        public string MethodColor { get; private set; }
        public string MessageColor { get; private set; }
        public string DataColor { get; private set; }
        
        public Style()
        {
#if UNITY_EDITOR
            FontSize = EditorPrefs.GetInt(Data.FontSizePrefId, Data.FontSizeDefaultValue);
            ClassColor = EditorPrefs.GetString(Data.ClassColorPrefId, Data.ClassColorDefaultValue);
            MethodColor = EditorPrefs.GetString(Data.MethodColorPrefId, Data.MethodColorDefaultValue);
            MessageColor = EditorPrefs.GetString(Data.MessageColorPrefId, Data.MessageColorDefaultValue);
            DataColor = EditorPrefs.GetString(Data.DataColorPrefId, Data.DataColorDefaultValue);
#endif
        }

        public Style(int fontSize, string classColor, string methodColor, string messageColor, string dataColor)
        {
            FontSize = fontSize;
            ClassColor = classColor;
            MethodColor = methodColor;
            MessageColor = messageColor;
            DataColor = dataColor;
        }

        public Style(int fontSize, Color classColor, Color methodColor, Color messageColor, Color dataColor)
        {
            FontSize = fontSize;
            ClassColor = Epilog.GetColorHEXString(classColor);
            MethodColor = Epilog.GetColorHEXString(methodColor);
            MessageColor = Epilog.GetColorHEXString(messageColor);
            DataColor = Epilog.GetColorHEXString(dataColor);
        }
    }
}
