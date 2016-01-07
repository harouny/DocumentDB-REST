﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using Newtonsoft.Json.Linq;

namespace DocumentDBRestApi.Models
{
    /// <summary>
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Initializes a new instance of the User class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the User class with required
        ///     arguments.
        /// </summary>
        public User(string id)
            : this()
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Id = id;
        }

        /// <summary>
        ///     Optional. This is a system generated property representing the
        ///     resource etag required for optimistic concurrency control.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property denoting the
        ///     addressable path of the feed of permissions resource.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property.
        /// </summary>
        public string Rid { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property. It specifies the
        ///     last updated timestamp of the resource. The value is a timestamp.
        /// </summary>
        public string Ts { get; set; }

        /// <summary>
        ///     Required. This is the only user settable property. It is a unique
        ///     name that identifies a user, i.e. no two users share the same id
        ///     within a database. The name must not exceed 255 characters.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Serialize the object
        /// </summary>
        /// <returns>
        ///     Returns the json model for the type User
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            if (Etag != null)
            {
                outputObject["_etag"] = Etag;
            }
            if (Permissions != null)
            {
                outputObject["_permissions"] = Permissions;
            }
            if (Rid != null)
            {
                outputObject["_rid"] = Rid;
            }
            if (Self != null)
            {
                outputObject["_self"] = Self;
            }
            if (Ts != null)
            {
                outputObject["_ts"] = Ts;
            }
            if (Id != null)
            {
                outputObject["id"] = Id;
            }
            return outputObject;
        }

        /// <summary>
        ///     Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject == null || inputObject.Type == JTokenType.Null) return;
            var etagValue = inputObject["_etag"];
            if (etagValue != null && etagValue.Type != JTokenType.Null)
            {
                Etag = (string) etagValue;
            }
            var permissionsValue = inputObject["_permissions"];
            if (permissionsValue != null && permissionsValue.Type != JTokenType.Null)
            {
                Permissions = (string) permissionsValue;
            }
            var ridValue = inputObject["_rid"];
            if (ridValue != null && ridValue.Type != JTokenType.Null)
            {
                Rid = (string) ridValue;
            }
            var selfValue = inputObject["_self"];
            if (selfValue != null && selfValue.Type != JTokenType.Null)
            {
                Self = (string) selfValue;
            }
            var tsValue = inputObject["_ts"];
            if (tsValue != null && tsValue.Type != JTokenType.Null)
            {
                Ts = (string) tsValue;
            }
            var idValue = inputObject["id"];
            if (idValue != null && idValue.Type != JTokenType.Null)
            {
                Id = (string) idValue;
            }
        }
    }
}