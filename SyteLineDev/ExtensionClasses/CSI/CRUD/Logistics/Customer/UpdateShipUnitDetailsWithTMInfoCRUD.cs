using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class UpdateShipUnitDetailsWithTMInfoCRUD : IUpdateShipUnitDetailsWithTMInfoCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;

        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        public UpdateShipUnitDetailsWithTMInfoCRUD(IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
        }

        #region CollectionUpdateRequest Shipment
        public (int Count, string Infobar) UpdateShipmentExternalInfo(decimal? shipmentID, string externalBolNum, string pRONumber, string trackingNumber)
        {
            string infobar = "";
            string shipmentExtBolNum = string.Empty;
            int count = 0;

            #region CRUD LoadToRecord
            var shipmentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"pro_number","shipment.pro_number"},
                {"tracking_number","shipment.tracking_number"},
                {"external_bol_num","shipment.external_bol_num"}
            },
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                maximumRows: 1,
                tableName: "shipment",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("shipment.shipment_id={0}", shipmentID),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var shipmentLoadResponse = this.appDB.Load(shipmentLoadRequest);

            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            if (shipmentLoadResponse.Items.Count > 0 && string.IsNullOrEmpty(shipmentExtBolNum) == true)
            {
                shipmentLoadResponse.Items[0].SetValue<string>("pro_number", pRONumber);
                shipmentLoadResponse.Items[0].SetValue<string>("tracking_number", trackingNumber);
                shipmentLoadResponse.Items[0].SetValue<string>("external_bol_num", externalBolNum);
                var shipmentRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "shipment",
                 items: shipmentLoadResponse.Items);
                this.appDB.Update(shipmentRequestUpdate);
                count = shipmentRequestUpdate.Items.Count;
            }


            #endregion UpdateByRecord


            return (count, infobar);
        }
        #endregion


        public (int Count, string Infobar) InsertCarrierShip(decimal? shipmentID, int? packageID, string trackingNumber, string proNumber, string truckloadNum, string siteShipmentId)
        {
            string infobar = "";

            #region CRUD LoadResponseWithoutTable
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "shipment_id", shipmentID },
                    { "package_id",packageID },
                    { "tracking_number",trackingNumber },
                    { "pro_number", proNumber },
                    { "truckload_num", truckloadNum },
                    { "site_ref_shipment_id", siteShipmentId },
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
            #endregion CRUD LoadResponseWithoutTable

            #region CRUD InsertByRecords
            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "carrier_ship",
                items: nonTableLoadResponse.Items);

            this.appDB.Insert(nonTableInsertRequest);
            #endregion InsertByRecords

            int count = nonTableInsertRequest.Items.Count;
            return (count, infobar);
        }
        public (int Count, string Infobar) DeleteCarrierShip(decimal? shipmentID)
        {
            string infobar = "";
            int count = 0;
            var carrierShipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"shipment_id","[shipment_id]"},
            },
            loadForChange: true,
            lockingType: LockingType.None,
            tableName: "carrier_ship",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("shipment_id = {0}", shipmentID),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var carrierShipLoadResponse= this.appDB.Load(carrierShipLoadRequest);

            if (carrierShipLoadResponse.Items.Count > 0)
            {
                var CarrierShipDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "carrier_ship",
               items: carrierShipLoadResponse.Items);
                this.appDB.Delete(CarrierShipDeleteRequest);
                count = CarrierShipDeleteRequest.Items.Count;

            }
            return (count, infobar);
        }

    }
}
