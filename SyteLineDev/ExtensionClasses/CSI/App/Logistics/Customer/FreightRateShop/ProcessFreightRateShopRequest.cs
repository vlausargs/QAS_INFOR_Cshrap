using CSI.Data.CRUD;
using CSI.Data.Net;
using CSI.Data.Utilities;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CSI.Logistics.Customer
{
    public interface IProcessFreightRateShopRequest
    {
        (int severity, string infobar, int? httpResponseCode, string jsonResponses, decimal CarrierUpchargePct) Process(string bearerToken, string URL, string tenantId, string customer, int custSeq, string coNum, string shipVia, decimal? shipmentId, string TransactionType);
    }

    public class ProcessFreightRateShopRequest : IProcessFreightRateShopRequest
    {
        #region Const Variables
        private const string httpMethod = "POST";
        private const string contentType = "application/json";
        private const int timeout = 10000;
        #endregion


        IGetFreightRateShopRequest getFreightRateShopRequest;
        IFreightRateShopResponseHandler freightRateShopResponseHandler;
        ICSIRequesterFactory cSIRequesterFactory;
        IStreamReaderUtilFactory streamReaderUtilFactory;
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        IUnionUtil unionUtil;
        IApplicationDB appDB;
        IProcessFreightRateShopRequestCRUD processFreightRateShopRequestCRUD;
        ICalcFreightAmounts calcFreightAmounts;

        public ProcessFreightRateShopRequest(IGetFreightRateShopRequest getFreightRateShopRequest, IFreightRateShopResponseHandler freightRateShopResponseHandler, ICSIRequesterFactory cSIRequesterFactory, IStreamReaderUtilFactory streamReaderUtilFactory, ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory, IUnionUtil unionUtil, IApplicationDB appDB, IProcessFreightRateShopRequestCRUD processFreightRateShopRequestCRUD, ICalcFreightAmounts calcFreightAmounts)
        {

            this.getFreightRateShopRequest = getFreightRateShopRequest;
            this.freightRateShopResponseHandler = freightRateShopResponseHandler;
            this.cSIRequesterFactory = cSIRequesterFactory;
            this.streamReaderUtilFactory = streamReaderUtilFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.unionUtil = unionUtil;
            this.appDB = appDB;
            this.processFreightRateShopRequestCRUD = processFreightRateShopRequestCRUD;
            this.calcFreightAmounts = calcFreightAmounts;
        }

        public (int severity, string infobar, int? httpResponseCode, string jsonResponses, decimal CarrierUpchargePct) Process(string bearerToken, string URL, string tenantId, string customer, int custSeq, string coNum, string shipVia, decimal? shipmentId, string TransactionType)
        {
            int severity = 0;
            string infobar = "";
            int? httpResponseCode = null;
            string response = "";
            ICollectionLoadResponse freightRateShopRequests = null;
            decimal carrierUpchargePct = 0.0M;

            (severity, infobar) = calcFreightAmounts.GetCarrierUpchargePct(customer, custSeq, ref carrierUpchargePct);
            if (severity != 0)
            {
                return (severity, infobar, httpResponseCode, response, carrierUpchargePct);
            }

            if (TransactionType == "Shipment")
            {
                (severity, infobar, freightRateShopRequests) = getFreightRateShopRequest.Process(shipmentId, shipVia, tenantId);
                if (severity != 0)
                {
                    return (severity, infobar, httpResponseCode, response, carrierUpchargePct);
                }
            }
            else if (TransactionType == "CO")
            {
                (severity, infobar, freightRateShopRequests) = getFreightRateShopRequest.Process(customer, coNum, shipVia, tenantId);
                if (severity != 0)
                {
                    return (severity, infobar, httpResponseCode, response, carrierUpchargePct);
                }

            }

            (severity, infobar, httpResponseCode, response) = RequestFreightRate(bearerToken, URL, tenantId, freightRateShopRequests);

            return (severity, infobar, httpResponseCode, response, carrierUpchargePct);
        }

        private (int severity, string infobar, int? httpResponseCode, string responses) RequestFreightRate(string bearerToken, string URL, string tenantId, ICollectionLoadResponse freightRateShopRequests)
        {
            int severity = 0;
            string infobar = "";
            string methodParms = "";
            int? httpResponseCode = 0;
            string responses = "";
            string responseBody = "";
            ICollectionLoadResponse freightRateShopResponse = null;

            foreach (var item in freightRateShopRequests.Items)
            {
                methodParms = item.GetValue<string>("freightRateShopRequest");

                (severity, infobar, httpResponseCode, responseBody) = this.InvokeFreightRateShopAPI(bearerToken, URL, tenantId, httpMethod, methodParms, contentType);

                if (severity != 0)
                {
                    return (severity, infobar, httpResponseCode, responseBody);
                }

                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            {"freightRateShopResponse", responseBody}
                        });
                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                unionUtil.Add(nonTableLoadResponse);
            }

            freightRateShopResponse = unionUtil.Process();

            (severity, infobar, responses) = freightRateShopResponseHandler.HandleFreightRateShopSuccessResponse(httpResponseCode, freightRateShopResponse);


            return (severity, infobar, httpResponseCode, responses);
        }

        private (int severity, string infobar, int? httpResponseCode, string responseBody) InvokeFreightRateShopAPI(string bearerToken, string URL, string tenantId, string httpMethod, string methodParams, string requestContentType)
        {
            int severity = 0;
            string infobar = "";
            string responseBody = "";
            int? httpResponseCode = 200;
            string accept = "*/*";

            try
            {
                string serverURL = ServerAPIMethodUrl(URL, tenantId);

                var cSIRequester = cSIRequesterFactory.Create();
                var webRequest = cSIRequester.Create(serverURL, httpMethod, requestContentType, accept);
                webRequest.Headers.Add("Authorization", "Bearer " + bearerToken);

                var webResponse = cSIRequester.Call(webRequest, methodParams);

                var reader = streamReaderUtilFactory.Create(webResponse.GetResponseStream(), Encoding.UTF8);
                responseBody = reader.ReadToEnd();
                reader.Dispose();

            }
            catch (Exception e)
            {
                if (e is WebException)
                {

                    (severity, infobar, httpResponseCode) = freightRateShopResponseHandler.HandleFreightRateShopErrorResponse((WebException)e);
                }
                else
                {
                    httpResponseCode = 0;
                    severity = 16;
                    infobar = e.Message;
                }
            }

            return (severity, infobar, httpResponseCode, responseBody);
        }

        private string ServerAPIMethodUrl(string URL, string tenantId)
        {
            var freightRateShopIONAPISuiteMethod = processFreightRateShopRequestCRUD.GetFreightRateShopIONAPISuiteMethod("Infor Rate Shopping - TM", "ShopRate_GetRates");
            string suiteContext = freightRateShopIONAPISuiteMethod.SuiteContext;
            string methodPath = freightRateShopIONAPISuiteMethod.Path;
            string serverAPIMethodUrl = "";

            serverAPIMethodUrl = $@"{URL}/{tenantId}/{suiteContext}{methodPath}";

            return serverAPIMethodUrl;
        }
    }
}
