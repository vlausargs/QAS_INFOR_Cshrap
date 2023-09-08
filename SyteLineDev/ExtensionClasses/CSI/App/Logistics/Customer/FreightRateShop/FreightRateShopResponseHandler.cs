using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Utilities;
using CSI.Serializer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System;

namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopResponseHandler
    {
        (int severity, string infobar, string jsonResponses) HandleFreightRateShopSuccessResponse(int? httpResponseCode, ICollectionLoadResponse response);
        (int severity, string infobar,int? httpResponseCode) HandleFreightRateShopErrorResponse(WebException webException);
    }
    public class FreightRateShopResponseHandler : IFreightRateShopResponseHandler
    {
        IMsgApp msgApp;
        IStreamReaderUtilFactory streamReaderUtilFactory;
        ISerializerFactory serializerFactory;

        public FreightRateShopResponseHandler(IMsgApp msgApp, IStreamReaderUtilFactory streamReaderUtilFactory, ISerializerFactory serializerFactory)
        {
            this.msgApp = msgApp;
            this.streamReaderUtilFactory = streamReaderUtilFactory;
            this.serializerFactory = serializerFactory;

        }

        public (int severity, string infobar,string jsonResponses) HandleFreightRateShopSuccessResponse(int? httpResponseCode, ICollectionLoadResponse responses)
        {
            int severity = 0;
            string infobar = "";
            string jsonResponses = "";
            var serializer= serializerFactory.Create(SerializerType.NewtonConvert);
            try
            {
                var reponseList = responses.Items.Select(x => x.GetValue<string>(0)).ToList();
                if (httpResponseCode == 200 && reponseList!=null)
                {
                    jsonResponses = serializer.Serialize<IList<string>>(reponseList);
                }
            }
            catch (Exception e)
            {
                severity = 16;
                infobar = e.Message;
            }

            return (severity, infobar, jsonResponses);
        }


        public (int severity, string infobar,int?httpResponseCode) HandleFreightRateShopErrorResponse(WebException webException)
        {

            int severity = 0;
            string infobar = "";
            string error = "";
            int httpResponseCode;
            string response;
            var serializer = serializerFactory.Create(SerializerType.NewtonConvert);


            var errorhttpwebResponse = webException.Response as HttpWebResponse;
            httpResponseCode = (int)errorhttpwebResponse.StatusCode;

            var reader = streamReaderUtilFactory.Create(errorhttpwebResponse.GetResponseStream(), Encoding.UTF8);
            response = reader.ReadToEnd();
            reader.Dispose();

            if (httpResponseCode == 400)
            {
                IFreighRateShopValidationProblemDetails freightRateShopResponse = serializer.Deserialize<FreighRateShopValidationProblemDetails>(response);
                error = freightRateShopResponse.title == null ? "" : freightRateShopResponse.title;
                (severity, infobar) = msgApp.MsgAppSp(infobar, "!FreightRateShopRequestError", "@!BadRequest", error);
            }
            else if (httpResponseCode == 404)
            {
                IFreighRateShopProblemDetails freightRateShopResponse = serializer.Deserialize<FreighRateShopProblemDetails>(response);
                error = freightRateShopResponse.title == null ? "" : freightRateShopResponse.detail;
                (severity, infobar) = msgApp.MsgAppSp(infobar, "!FreightRateShopRequestError", "@!PageNotFound", error);
            }
            else if (httpResponseCode == 500)
            {
                IFreighRateShopProblemDetails freightRateShopResponse = serializer.Deserialize<FreighRateShopProblemDetails>(response);
                error = freightRateShopResponse.title == null ? "" : freightRateShopResponse.detail;
                (severity, infobar) = msgApp.MsgAppSp(infobar, "!FreightRateShopRequestError", "@!InternalServer", error);
            }
            else if (httpResponseCode == 200)
            {
                severity = 0;
                infobar = "";
            }
            else 
            {
                (severity, infobar) = msgApp.MsgAppSp(infobar, "!FreightRateShopRequestError", webException.Message);
            }

            return (severity, infobar, httpResponseCode);
        }

    }
}
