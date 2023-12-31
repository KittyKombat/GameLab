﻿using UnityEditor;
using UnityEngine;


    [CustomEditor(typeof(HexaComments))]
    public class HexaCommentsInspector : UnityEditor.Editor
    {
        private HexaComments Comments { get { return target as HexaComments; } }
        private readonly GUIStyle style = new GUIStyle(EditorStyles.helpBox);

        // Colors
        private static Color DarkSkinFontColor = new Color(.8f, .8f, .8f, 1f);//new Color(0.5f, 0.7f, 0.3f, 1f);
        private static Color NormalFontColor = new Color(0.2f, 0.3f, 0.1f, 1f);

        public override void OnInspectorGUI()
        {
            if (serializedObject == null)
                return;

            
            style.wordWrap = true;
            style.fontSize = 15;
            style.normal.textColor = EditorGUIUtility.isProSkin ? DarkSkinFontColor : NormalFontColor;

            serializedObject.Update();
            EditorGUILayout.Space();

            var updatedText = EditorGUILayout.TextArea(Comments.text, style);
            if (updatedText != Comments.text)
            {
                Undo.RecordObject(Comments, "Edit Comments");
                Comments.text = updatedText;
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space();
        }
    }
