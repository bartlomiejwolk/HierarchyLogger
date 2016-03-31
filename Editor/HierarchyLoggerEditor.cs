// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the HierarchyLogger extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace HierarchyLoggerEx {

    [CustomEditor(typeof(HierarchyLogger))]
    [CanEditMultipleObjects]
    public sealed class HierarchyLoggerEditor : Editor {
        #region FIELDS

        private HierarchyLogger Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty awakeMessage;
        private SerializedProperty startMessage;
        private SerializedProperty onDestroyMessage;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawAwakeMessageField();
            DrawStartMessageField();
            DrawOnDisableMessageField();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (HierarchyLogger)target;

            description = serializedObject.FindProperty("description");
            awakeMessage = serializedObject.FindProperty("awakeMessage");
            startMessage = serializedObject.FindProperty("startMessage");
            onDestroyMessage =
                serializedObject.FindProperty("onDestroyMessage");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawOnDisableMessageField() {
            EditorGUILayout.PropertyField(
                onDestroyMessage,
                new GUIContent(
                    "Destroy",
                    "This message will be logged into Unity console " +
                    "OnDestroy()."));
        }

        private void DrawStartMessageField() {
            EditorGUILayout.PropertyField(
                startMessage,
                new GUIContent(
                    "Start",
                    "This message will be logged into Unity console " +
                    "on Start()."));
        }

        private void DrawAwakeMessageField() {
            EditorGUILayout.PropertyField(
                awakeMessage,
                new GUIContent(
                    "Awake",
                    "This message will be logged into Unity console " +
                    "on Awake()."));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    HierarchyLogger.Version,
                    HierarchyLogger.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Component Framework/HierarchyLogger")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(HierarchyLogger));
            }
        }

        #endregion METHODS
    }

}