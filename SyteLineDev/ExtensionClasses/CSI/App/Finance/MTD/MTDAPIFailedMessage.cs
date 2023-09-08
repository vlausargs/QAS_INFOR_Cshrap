using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CSI.Serializer;

namespace CSI.Finance.MTD
{
    public class MTDAPIFailedMessage : IMTDAPIFailedMessage
    {
        private readonly ISerializer _serializer;

        public MTDAPIFailedMessage(ISerializer serializer)
        {
            _serializer = serializer;
        }

        // TODO : remove back to MTD
        public Dictionary<string, string> GetCallFailedMassage(WebException e)
        {
            var dictionary = new Dictionary<string, string>
            {
                {"code", ""},
                {"message", ""}
            };

            var errorMassage = string.Empty;

            if (e.Status == WebExceptionStatus.ProtocolError && e.Response is HttpWebResponse response)
            {
                using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    errorMassage = reader.ReadToEnd();
                }
            }

            if (string.IsNullOrWhiteSpace(errorMassage))
            {
                return dictionary;
            }

            var errorMessageDictionary = _serializer.Deserialize<Dictionary<string, object>>(errorMassage);

            // if error message contains more than 2 keys, code and message. like error demo belowed

            #region Complex Error Msg

            /*{
                "code": "INVALID_REQUEST",
                "message": "Invalid request",
                "errors": [
                {
                    "code": "PERIOD_KEY_INVALID",
                    "message": "period key should be a 4 character string",
                    "path": "/periodKey"
                }
                ]
            }*/

            #endregion

            if (errorMessageDictionary.Keys.Last() == "errors")
            {
                // Only handle the first error
                // TODO: Maybe can handle multi error

                var errorMessageList =
                    _serializer.Deserialize<List<Dictionary<string, object>>>(errorMessageDictionary.Values.Last().ToString());

                dictionary["code"] = errorMessageList[0].Values.First() + ": ";
                dictionary["message"] = errorMessageList[0].Values.Skip(1).First().ToString();

                return dictionary;
            }

            dictionary["code"] = errorMessageDictionary.Values.First() + ": ";
            dictionary["message"] = errorMessageDictionary.Values.Last().ToString();

            return dictionary;
        }
    }
}