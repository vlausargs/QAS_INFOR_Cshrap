using System.Collections.Generic;
using System.Data;
using System.Linq;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Serializer;
using System;
using Newtonsoft.Json;

namespace CSI.Logistics.Customer
{
    public interface IGetFreightRateShop
    {
        DataTable CLM_FreightRateShop(string freightRateShopResponseJsonString, int? httpResponseCode);
    }
    public class GetFreightRateShop : IGetFreightRateShop
    {

        ISerializerFactory serializerFactory;
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        IUnionUtil unionUtil;
        IApplicationDB appDB;
        IRecordCollectionToDataTable recordCollectionToDataTable;

        public GetFreightRateShop(ISerializerFactory serializerFactory, ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory, IUnionUtil unionUtil, IApplicationDB appDB, IRecordCollectionToDataTable recordCollectionToDataTable)
        {
            this.serializerFactory = serializerFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.unionUtil = unionUtil;
            this.appDB = appDB;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
        }

        public DataTable CLM_FreightRateShop(string freightRateShopResponsesJsonString, int? httpResponseCode)
        {
            ICollectionLoadResponse Data = null;
            DataTable tblReturn = null;
            DataTable tblResponses = null;
            var serializer = serializerFactory.Create(SerializerType.NewtonConvert);
            try
            {
                if (httpResponseCode == 200 && !string.IsNullOrEmpty(freightRateShopResponsesJsonString))
                {

                    var freightRateShopResponses = serializer.Deserialize<List<string>>(freightRateShopResponsesJsonString);

                    if (freightRateShopResponses != null)
                    {
                        for (int i = 0; i < freightRateShopResponses.Count; i++)
                        {
                            var freightRateShopResponse = serializer.Deserialize<FreightRateShopResponse>(freightRateShopResponses[i]);
                            foreach (var rateRecords in freightRateShopResponse.RateRecords)
                            {
                                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                            {
                                { "CarrierCode", rateRecords.CarrierCode},
                                { "CarrierName", rateRecords.CarrierName},
                                { "ServiceLevel", rateRecords.ServiceLevel},
                                { "ServiceLevelCode", rateRecords.ServiceLevelCode},
                                { "TotalRatedAmount", rateRecords.TotalRatedAmount},
                                { "CurrencyCode", rateRecords.CurrencyCode},
                            });
                                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                                unionUtil.Add(nonTableLoadResponse);
                            }
                        }
                        Data = unionUtil.Process();
                        tblResponses = recordCollectionToDataTable.ToDataTable(Data.Items);

                        if (tblResponses.Rows.Count != 0)
                        {
                            tblReturn = tblResponses.AsEnumerable()
                               .GroupBy(g => new
                               {
                                   CarrierCode = g.Field<string>("CarrierCode"),
                                   CarrierName = g.Field<string>("CarrierName"),
                                   ServiceLevel = g.Field<string>("ServiceLevel"),
                                   ServiceLevelCode = g.Field<string>("ServiceLevelCode"),
                                   CurrencyCode = g.Field<string>("CurrencyCode"),
                               })
                                .Select(s =>
                                {
                                    var row = tblResponses.NewRow();

                                    row["CarrierCode"] = s.Key.CarrierCode;
                                    row["CarrierName"] = s.Key.CarrierName;
                                    row["ServiceLevel"] = s.Key.ServiceLevel;
                                    row["ServiceLevelCode"] = s.Key.ServiceLevelCode;
                                    row["TotalRatedAmount"] = s.Sum(r => r.Field<decimal>("TotalRatedAmount"));
                                    row["CurrencyCode"] = s.Key.CurrencyCode;

                                    return row;

                                }).CopyToDataTable();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return tblReturn;
        }

    }
}
