using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace EPILOG // EditorPrettyIdleLOGger ;)
{
    public static class Epilog 
    {
        private static Style _style = new Style();
        public static Style Style => _style;

        public static void SetStyle(Style style)
        {
            _style = style;
        }

        public static void SetStyle(int fontSize, string classColor, string methodColor, string messageColor, string dataColor)
        {
            SetStyle(new Style(fontSize, classColor, methodColor, messageColor, dataColor));
        }

        public static void SetStyle(int fontSize, Color classColor, Color methodColor, Color messageColor, Color dataColor)
        {
            SetStyle(new Style(fontSize, classColor, methodColor, messageColor, dataColor));
        }

        public static void Print(string message, params object[] @params)
        {
            Print(LogType.Log, message, @params);
        }

        public static void Print(LogType logType, object message, params object[] @params)
        {
            var stackTrace = new System.Diagnostics.StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            //var parameters = stackTrace.GetFrame(1).GetMethod().GetParameters();
            // var prs =  
            //     parameters.Any() ? parameters.Select(p => $"{p}").Aggregate((p1, p2) => $"{p1}, {p2}") : String.Empty;

            // Shrug(prs);

            var extendedMessage = GetMessage(method.ReflectedType.Name, method.Name, message, @params);
            
            Debug.unityLogger.Log(logType, extendedMessage);
        }

        public static void Print()
        {
            Debug.Log("\n");
        }

        public static void Shrug(string shrugMessage = "") => Debug.Log(GetMessage($@"{shrugMessage} ¯\_(ツ)_/¯"));
        public static void Error(string errorMessage) => Print(LogType.Error, errorMessage);
        public static void Warning(string warningMessage) => Print(LogType.Warning, warningMessage);
        public static void Exception(Exception exception) => Print(LogType.Exception, exception);
        public static void Assertion(object assertion) => Print(LogType.Assert, assertion);

		public static string GetMessage(object message)
        {
            return SetFontColor(SetFontSize($"{message}", _style.FontSize), _style.MessageColor);
        }

        public static string GetMessage(string @class, string method, object message, object[] args)
        {
            var argsString = 
                args.Any() ? args.Select(arg => $"{arg}").Aggregate((arg1, arg2) => $"{arg1}, {arg2}") : String.Empty;

            return
                $"<b><size={ _style.FontSize}>" +
                    $"<color={_style.ClassColor}>[{@class}]</color>" +
                    $"<color={_style.MethodColor}>[{method}]</color>" +
                    $"<color={_style.MessageColor}> {message}</color>" +
                    $"<color={_style.DataColor}> [{argsString}]</color>" +
                "</size></b>";
        }

        public static string GetMessage(string @class, string method, object message)
        {
            return SetFontSize($"[{@class}][{method}] {message}");
        }

        public static string GetMessage<T>(string @class, string method, IEnumerable<T> args)
        {
            var j = 0;
            var message = 
                args.Any() ? args.Select(arg => $"[{j++}:{arg}]").Aggregate((arg1, arg2) => $"{arg1}{arg2}") : "Collection is empty!";

            return SetFontSize($"[{@class}][{method}] {message}");
        }

        public static string GetMessage(Color color, string message)
        {
            var tmp = (Color32) color;
            return SetFontSize($"<color=#{tmp.r:X2}{tmp.g:X2}{tmp.b:X2}> \u2587 </color>{message}");
        }

        public static string GetMessage(Color32 color, string message)
        {
            return SetFontSize($"<color=#{color.r:X2}{color.g:X2}{color.b:X2}> \u2587 </color>{message}");
        }

        private static string SetFontSize(string message, int fontSize = 14)
        {
            return $"<size={fontSize}>{message}</size>";
        }

        private static string SetFontColor(string message, Color fontColor)
        {
            return $"<color={GetColorHEXString(fontColor)}>{message}</color>";
        }

        private static string SetFontColor(string message, string fontColor)
        {
            return $"<color={fontColor}>{message}</color>";
        }

        public static string GetColorHEXString(Color color)
        {
            var tmp = (Color32) color;
            return $"#{tmp.r:X2}{tmp.g:X2}{tmp.b:X2}";
        }

        private static string SetFontColor(object message, Color fontColor)
        {
            return SetFontColor(message.ToString(), fontColor);
        }
    }
}
        