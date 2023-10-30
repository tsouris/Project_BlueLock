using System;
using System.Collections.Generic;

namespace Project_BlueLock.Utilities
{
    /// <summary>
    /// Manages subscriptions and notifications using a token-based system. 
    /// It allows components to subscribe to specific events (identified by tokens) and be notified when those events occur. 
    /// It also supports unsubscribing from events. 
    /// </summary>
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> pl_dict =
           new Dictionary<string, List<Action<object>>>();

        public static void Subscribe(string token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in pl_dict[token])
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;
                if (!found)
                    pl_dict[token].Add(callback);
            }
        }

        public static void Unsubscribe(string token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
                pl_dict[token].Remove(callback);
        }

        public static void Notify(string token, object args = null)
        {
            if (pl_dict.ContainsKey(token))
                foreach (var callback in pl_dict[token])
                    callback(args);
        }
    }
}
