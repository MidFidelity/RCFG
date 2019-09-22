using System;
using System.Collections.Generic;
using UnityEngine;

namespace nvp.events
{
    public class EventManager
    {
        public static Dictionary<string, GameEventWrapper> EventHandlers;

        static EventManager()
        {
            EventHandlers = new Dictionary<string, GameEventWrapper>();
        }

        public static GameEventWrapper Events(string eventName)
        {
            if (!EventHandlers.ContainsKey(eventName))
                EventHandlers[eventName] = new GameEventWrapper(eventName);

            return EventHandlers[eventName];
        }
    }

    public class GameEventWrapper
    {
        public event EventHandler GameEventHandler;
        public string eventName;

        public GameEventWrapper(string eventName)
        {
            this.eventName = eventName;
        }
        public void TriggerEvent(object sender, EventArgs eventArgs)
        {
            Debug.Log(eventName);
           GameEventHandler?.Invoke(sender, eventArgs);
        }
    }

    // Sample EventArgs
    public class DefaultEventArgs : EventArgs
    {
        public object Value;
    }
}