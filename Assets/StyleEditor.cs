#if UNITY_EDITOR
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;
using UnityEditor;

namespace EPILOG
{
	public class StyleEditor :  EditorWindow 
	{
		private int _fontSize;
		private Color _classColor;
		private Color _methodColor;
		private Color _messageColor;
		private Color _dataColor;

        [MenuItem("Window/EPILOG/Style editor")]
        public static void ShowEditor() => GetWindow(typeof(StyleEditor));

		private void OnEnable() => LoadStyle();
		private void OnDisable() => SaveStyle();
		 
		private void OnGUI()
		{
			GUILayout.Label("Log style", EditorStyles.boldLabel);
			_fontSize = EditorGUILayout.IntField("Font size", _fontSize);
         	_classColor = EditorGUILayout.ColorField("Class color", _classColor);
        	_methodColor = EditorGUILayout.ColorField("Method color", _methodColor);
        	_messageColor = EditorGUILayout.ColorField("Message color", _messageColor);
        	_dataColor = EditorGUILayout.ColorField("Data color", _dataColor);

			if (GUILayout.Button("Save to EditorPrefs"))
			{
				SaveStyle();
				Epilog.Print("Color switched");
			}

			if (GUILayout.Button("Save to file"))
			{
				EditorUtility.SaveFilePanel("Save style data to file", @"C:\Users\vladimir_fly\Downloads\", "style", "epilog");
			}

			if (GUILayout.Button("Load from EditorPrefs"))
			{
				Deserialize();
			}

			if (GUILayout.Button("Load from file"))
			{
				EditorUtility.OpenFilePanel("Load style data from file", @"C:\Users\vladimir_fly\Downloads\", "epilog");

			}
		}

		public void SaveStyle()
		{
			Epilog.SetStyle(_fontSize, _classColor, _methodColor, _messageColor, _dataColor);

			EditorPrefs.SetInt(Data.FontSizePrefId, Epilog.Style.FontSize);
			EditorPrefs.SetString(Data.ClassColorPrefId, Epilog.Style.ClassColor);
			EditorPrefs.SetString(Data.MethodColorPrefId, Epilog.Style.MethodColor);
			EditorPrefs.SetString(Data.MessageColorPrefId, Epilog.Style.MessageColor);
			EditorPrefs.SetString(Data.DataColorPrefId, Epilog.Style.DataColor);
		}

		public void LoadStyle()
		{
			_fontSize = EditorPrefs.GetInt(Data.FontSizePrefId);
			ColorUtility.TryParseHtmlString(EditorPrefs.GetString(Data.ClassColorPrefId), out _classColor);
            ColorUtility.TryParseHtmlString(EditorPrefs.GetString(Data.MethodColorPrefId), out _methodColor);
			ColorUtility.TryParseHtmlString(EditorPrefs.GetString(Data.MessageColorPrefId), out _messageColor);
			ColorUtility.TryParseHtmlString(EditorPrefs.GetString(Data.DataColorPrefId), out _dataColor);
		}

		private void SaveToFile()
		{
			var style = Epilog.Style;
			var formatter = new BinaryFormatter();
			
			using (var fs = new FileStream(@"C:\Users\vladimir_fly\Downloads\style.epilog", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, style);
				Epilog.Print("serialized");
			}
		}

		private void Deserialize()
		{
			var formatter = new BinaryFormatter();
 
			using (var fs = new FileStream(@"C:\Users\vladimir_fly\Downloads\style.epilog", FileMode.OpenOrCreate))
			{
				var style = (Style) formatter.Deserialize(fs);
				Epilog.SetStyle(style); 
				Epilog.Print("deserialized", style.FontSize, style.ClassColor, style.MessageColor, style.MessageColor, style.DataColor);
			}
			
		}
	}
}
#endif
