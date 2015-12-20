﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DocumentDBRestApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public static class UserCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<User> DeserializeJson(JToken inputObject)
        {
            IList<User> deserializedObject = new List<User>();
            foreach (var iListValue in ((JArray)inputObject))
            {
                var user = new User();
                user.DeserializeJson(iListValue);
                deserializedObject.Add(user);
            }
            return deserializedObject;
        }
    }
}
