// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the HierarchyLogger extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using System.Runtime.Remoting;
using UnityEngine;

namespace HierarchyLoggerEx {

    /// <summary>
    /// Allows output log info from game objects.
    /// </summary>
    public sealed class HierarchyLogger : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "HierarchyLogger";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "HierarchyLogger";
#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private string awakeMessage;

        [SerializeField]
        private string startMessage;

        [SerializeField]
        private string onDestroyMessage;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string StartMessage {
            get { return startMessage; }
            set { startMessage = value; }
        }

        public string AwakeMessage {
            get { return awakeMessage; }
            set { awakeMessage = value; }
        }

        public string OnDestroyMessage {
            get { return onDestroyMessage; }
            set { onDestroyMessage = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() {
            LogMessage(AwakeMessage, "Awake");
        }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() {
            LogMessage(StartMessage, "Start");
        }
        private void Update() { }

        private void OnValidate() { }

        private void OnDestroy() {
            LogMessage(OnDestroyMessage, "OnDestroy");
        }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="unityMessage">Unity message name.</param>
        private void LogMessage(string message, string unityMessage) {
            if (message == "") return;

            // todo use StringBuilder
            Debug.Log(
                //"Method: " + unityMessage
                //+ ", Game Object: " + gameObject.name
                //+ ", Message: " + message);
                "(Method) " + unityMessage
                + ", (Game Object) " + gameObject.name
                + ", (Message) " + message);
        }

        /// <summary>
        /// Log custom message.
        /// </summary>
        /// <param name="message"></param>
        public void LogMessage(string message) {
            Debug.Log(message);
        }

        #endregion METHODS

    }

}