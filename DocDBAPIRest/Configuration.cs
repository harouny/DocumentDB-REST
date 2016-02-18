using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DocDBAPIRest
{
    /// <summary>
    ///     Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        /// <summary>
        ///     VERSION of the package.
        /// </summary>
        /// <value>VERSION of the package.</value>
        public const string VERSION = "1.0.0";

        private const string ISO8601_DATETIME_FORMAT = "o";

        /// <summary>
        ///     Gets or sets the default Configuration.
        /// </summary>
        /// <value>Configuration.</value>
        public static Configuration Default = new Configuration();

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        private string _tempFolderPath = Path.GetTempPath();

        /// <summary>
        ///     Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The API client.</value>
        public ApiClient ApiClient;

        /// <summary>
        ///     Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public Dictionary<string, string> ApiKey = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public Dictionary<string, string> ApiKeyPrefix = new Dictionary<string, string>();

        /// <summary>
        ///     Initializes a new instance of the Configuration class with different settings
        /// </summary>
        /// <param name="apiClient">Api client</param>
        /// <param name="defaultHeader">Dictionary of default HTTP header</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="apiKey">Dictionary of API key</param>
        /// <param name="apiKeyPrefix">Dictionary of API key prefix</param>
        /// <param name="tempFolderPath">Temp folder path</param>
        /// <param name="dateTimeFormat">DateTime format string</param>
        /// <param name="timeout"></param>
        public Configuration(ApiClient apiClient = null,
            Dictionary<string, string> defaultHeader = null,
            string username = null,
            string password = null,
            string accessToken = null,
            Dictionary<string, string> apiKey = null,
            Dictionary<string, string> apiKeyPrefix = null,
            string tempFolderPath = null,
            string dateTimeFormat = null,
            int timeout = 100000
            )
        {
            if (apiClient == null)
                ApiClient = ApiClient.Default;
            else
                ApiClient = apiClient;

            Username = username;
            Password = password;
            AccessToken = accessToken;

            if (defaultHeader != null)
                DefaultHeader = defaultHeader;
            if (apiKey != null)
                ApiKey = apiKey;
            if (apiKeyPrefix != null)
                ApiKeyPrefix = apiKeyPrefix;

            TempFolderPath = tempFolderPath;
            DateTimeFormat = dateTimeFormat;
            Timeout = timeout;
        }

        /// <summary>
        ///     Initializes a new instance of the Configuration class.
        /// </summary>
        /// <param name="apiClient">Api client.</param>
        public Configuration(ApiClient apiClient)
        {
            ApiClient = apiClient ?? ApiClient.Default;
        }

        /// <summary>
        ///     Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        /// <value>Timeout.</value>
        public int Timeout
        {
            get { return ApiClient.RestClient.Timeout; }

            set { ApiClient.RestClient.Timeout = value; }
        }

        /// <summary>
        ///     Gets or sets the default header.
        /// </summary>
        public Dictionary<string, string> DefaultHeader { get; set; } = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the access token for OAuth2 authentication.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public string TempFolderPath
        {
            get { return _tempFolderPath; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value + Path.DirectorySeparatorChar;
            }
        }

        /// <summary>
        ///     Gets or sets the the date time format used when serializing in the ApiClient
        ///     By default, it's set to ISO 8601 - "o", for others see:
        ///     https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        ///     and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        ///     No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        ///     Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        public void AddDefaultHeader(string key, string value)
        {
            DefaultHeader.Add(key, value);
        }

        /// <summary>
        ///     Get the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            string apiKeyValue;
            ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            string apiKeyPrefix;
            if (ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            return apiKeyValue;
        }

        /// <summary>
        ///     Returns a string with essential information for debugging.
        /// </summary>
        public static string ToDebugReport()
        {
            var report = "C# SDK (DocDBRestAPI) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework VERSION: " + Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies().First(x => x.Name == "System.Core").Version + "\n";
            report += "    VERSION of the API: 1.0.6\n";
            report += "    SDK Package VERSION: 1.0.0\n";

            return report;
        }
    }
}