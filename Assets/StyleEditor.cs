using System.Collections;
using System.Collections.Generic;

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
        public static void ShowEditor() => EditorWindow.GetWindow(typeof(StyleEditor));

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
			 
			if (GUILayout.Button("Save"))
			{
				SaveStyle();
				Epilog.Print("Color switched");
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
    }
}