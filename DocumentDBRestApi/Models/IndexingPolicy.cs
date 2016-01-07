﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System.Collections.Generic;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json.Linq;

namespace DocumentDBRestApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexingPolicy
    {
        /// <summary>
        ///     Initializes a new instance of the IndexingPolicy class.
        /// </summary>
        public IndexingPolicy()
        {
            IndexingMode = new LazyList<string>();
        }

        /// <summary>
        ///     Required. True indicates that automatic indexing is on; otherwise,
        ///     False.
        ///     The default value is True, thus all documents are indexed by
        ///     default. Documents can be excluded by specifying the
        ///     x-ms-indexingdirective header value to “Exclude”.
        ///     Setting the value to False allows no documents are indexed.
        ///     Documents can be included by specifying the x-ms-indexingdirective
        ///     header value to “Include”.
        /// </summary>
        public bool Automatic { get; set; }

        /// <summary>
        ///     Required. The array containing the document paths to be excluded
        ///     from indexing. All properties are user settable.
        /// </summary>
        public ExcludePaths ExcludePaths { get; set; }

        /// <summary>
        ///     Required. The array containing the document paths to be indexed.
        ///     All properties are user settable.
        /// </summary>
        public string IncludePaths { get; set; }

        /// <summary>
        ///     Required. By default, the indexing mode is consistent. This means
        ///     that indexing occurs synchronously during insertion, replacement
        ///     or deletion of documents, and queries are served at the same
        ///     consistency level as configured in the request.
        ///     To have indexing occur asynchronously, set the indexing mode to
        ///     lazy. With lazy indexing, the index is updated when the collection
        ///     is operating below its request units per second capacity.
        /// </summary>
        public IList<string> IndexingMode { get; set; }

        /// <summary>
        ///     Required. The acceptable values are Hash or Range. Hash indexes are
        ///     useful for equality comparisons while Range indexes are useful for
        ///     range comparison. At the moment, range indexes can only be used
        ///     for numeric values.  The default value is Hash for document paths
        ///     and Range for a _ts path.
        /// </summary>
        public string IndexType { get; set; }

        /// <summary>
        ///     Required. The acceptable values are 1 to 7. The default value is 3.
        ///     This is the byte precision value for numeric values. The higher
        ///     this value is set, the lower the probability of term collision,
        ///     resulting in a faster and more accurate comparison. However, the
        ///     higher the value the greater the storage overhead.
        /// </summary>
        public int NumericPrecision { get; set; }

        /// <summary>
        ///     Required. The accepted value is a valid document path including
        ///     wildcards value of ? and *.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     Required. The acceptable values are 1 to 7. The default value is 3.
        ///     This is the byte precision value for strings. The higher this
        ///     value is set, the lower the probability of term collision,
        ///     resulting in a faster and more accurate comparison. However, the
        ///     higher the value the greater the storage overhead.
        /// </summary>
        public int StringPrecision { get; set; }

        /// <summary>
        ///     Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject == null || inputObject.Type == JTokenType.Null) return;
            var automaticValue = inputObject["automatic"];
            if (automaticValue != null && automaticValue.Type != JTokenType.Null)
            {
                Automatic = (bool) automaticValue;
            }
            var excludePathsValue = inputObject["ExcludePaths"];
            if (excludePathsValue != null && excludePathsValue.Type != JTokenType.Null)
            {
                var excludePaths = new ExcludePaths();
                excludePaths.DeserializeJson(excludePathsValue);
                ExcludePaths = excludePaths;
            }
            var includePathsValue = inputObject["IncludePaths"];
            if (includePathsValue != null && includePathsValue.Type != JTokenType.Null)
            {
                IncludePaths = (string) includePathsValue;
            }
            var indexingModeSequence = inputObject["indexingMode"];
            if (indexingModeSequence != null && indexingModeSequence.Type != JTokenType.Null)
            {
                foreach (var indexingModeValue in (JArray) indexingModeSequence)
                {
                    IndexingMode.Add((string) indexingModeValue);
                }
            }
            var indexTypeValue = inputObject["indexType"];
            if (indexTypeValue != null && indexTypeValue.Type != JTokenType.Null)
            {
                IndexType = (string) indexTypeValue;
            }
            var numericPrecisionValue = inputObject["NumericPrecision"];
            if (numericPrecisionValue != null && numericPrecisionValue.Type != JTokenType.Null)
            {
                NumericPrecision = (int) numericPrecisionValue;
            }
            var pathValue = inputObject["Path"];
            if (pathValue != null && pathValue.Type != JTokenType.Null)
            {
                Path = (string) pathValue;
            }
            var stringPrecisionValue = inputObject["StringPrecision"];
            if (stringPrecisionValue != null && stringPrecisionValue.Type != JTokenType.Null)
            {
                StringPrecision = (int) stringPrecisionValue;
            }
        }
    }
}