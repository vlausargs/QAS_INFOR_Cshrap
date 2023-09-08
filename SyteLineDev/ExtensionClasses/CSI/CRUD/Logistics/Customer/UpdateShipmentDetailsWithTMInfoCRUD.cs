using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class UpdateShipmentDetailsWithTMInfoCRUD : IUpdateShipmentDetailsWithTMInfoCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IExistsChecker existsChecker;
        public UpdateShipmentDetailsWithTMInfoCRUD(IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IExistsChecker existsChecker)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.existsChecker = existsChecker;
        }
        public bool ShipmentExists(decimal? shipmentId)
        {
            return existsChecker.Exists(tableName: "shipment",
           fromClause: collectionLoadRequestFactory.Clause(""),
           whereClause: collectionLoadRequestFactory.Clause("shipment_id={0}", shipmentId));
        }

        public bool ShipmentIsRated(decimal? shipmentId)
        {
            return existsChecker.Exists(tableName: "shipment",
           fromClause: collectionLoadRequestFactory.Clause(""),
           whereClause: collectionLoadRequestFactory.Clause("shipment_id={0} AND external_carrier_shipment_status='R'", shipmentId));
        }

        #region CollectionLoadRequest Shipment
        public (string ShipmentCurrCode, DateTime? ShipmentDate, string CORefNum, decimal? CarrierUpchargePercent, int? CustSeq) GetShipmentCustAddrDetailMethod(decimal? shipmentID)
        {
            CurrCodeType _ShipmentCurrCode = DBNull.Value;
            DateType _ShipmentDate = DBNull.Value;
            EmpJobCoPoRmaProjPsTrnNumType _CORefNum = DBNull.Value;
            CarrierUpchargePercentType _CarrierUpchargePercent = DBNull.Value;
            CustSeqType _CustSeq = DBNull.Value;
            string ShipmentCurrCode = null;
            DateTime? ShipmentDate = null;
            string CORefNum = null;
            decimal? CarrierUpchargePercent = null;
            int? CustSeq = null;

            #region CRUD LoadToVariable
            var shipCustAddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ShipmentCurrCode,"custaddr.curr_code"},
                    {_ShipmentDate, "shipment.ship_date" },
                    {_CORefNum, "shipment_line.ref_num"},
                    {_CarrierUpchargePercent, "custaddr.carrier_upcharge_pct"},
                    {_CustSeq, "shipment.cust_seq"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipment",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN custaddr ON " +
                                                                    "custaddr.cust_num=shipment.cust_num " +
                                                                    "AND custaddr.cust_seq=shipment.cust_seq " +
                                                                "LEFT OUTER JOIN shipment_line ON " +
                                                                    "shipment_line.shipment_id=shipment.shipment_id "),
                whereClause: collectionLoadRequestFactory.Clause("shipment.shipment_id={0}", shipmentID),
                orderByClause: collectionLoadRequestFactory.Clause("shipment_line.shipment_line"));

            var shipCustAddrLoadResponse = this.appDB.Load(shipCustAddrLoadRequest);
            if (shipCustAddrLoadResponse.Items.Count > 0)
            {
                ShipmentCurrCode = _ShipmentCurrCode;
                ShipmentDate = _ShipmentDate;
                CORefNum = _CORefNum;
                CarrierUpchargePercent = _CarrierUpchargePercent;
                CustSeq = _CustSeq;
            }
            #endregion

            return (ShipmentCurrCode, ShipmentDate, CORefNum, CarrierUpchargePercent, CustSeq);
        }
        #endregion

        #region CollectionUpdateRequest CO
        public (int Count, string Infobar) UpdateCoExternalShipmentFreight(string coRefNum, decimal? externalFreightChargeAmount)
        {
            string infobar = "";
            decimal? addCoExternalFreight = 0.0M;


            #region CRUD LoadToRecord
            var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {

                {"external_freight","co.external_freight" },
            },
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                maximumRows: 1,
                tableName: "co",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("co.co_num={0}", coRefNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coLoadResponse = this.appDB.Load(coLoadRequest);

            #endregion  LoadToRecord


            #region CRUD UpdateByRecord
            if (coLoadResponse.Items.Count > 0)
            {
                addCoExternalFreight = coLoadResponse.Items[0].GetValue<decimal?>("external_freight").GetValueOrDefault(0);
                externalFreightChargeAmount += addCoExternalFreight;
                coLoadResponse.Items[0].SetValue<decimal?>("external_freight", externalFreightChargeAmount);
            }
            var coRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "co",
                items: coLoadResponse.Items);

            this.appDB.Update(coRequestUpdate);
            #endregion UpdateByRecord

            int count = coRequestUpdate.Items.Count;

            return (count, infobar);
        }
        #endregion

        #region CollectionUpdateRequest Shipment
        public (int Count, string Infobar) UpdateExternalShipmentFreight(decimal? shipmentID, decimal? externalFreightChargeAmount, char externalCarrierShipmentStatus, string externalShipmentMessage)
        {
            string infobar = "";

            #region CRUD LoadToRecord
            var shipmentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {

                {"external_carrier_shipment_status","shipment.external_carrier_shipment_status"},
                {"external_freight","shipment.external_freight" },
                {"external_shipment_message","shipment.external_shipment_message"}
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
            if (shipmentLoadResponse.Items.Count > 0)
            {
                shipmentLoadResponse.Items[0].SetValue<decimal?>("external_freight", externalFreightChargeAmount);
                shipmentLoadResponse.Items[0].SetValue<char>("external_carrier_shipment_status", externalCarrierShipmentStatus);
                shipmentLoadResponse.Items[0].SetValue<string>("external_shipment_message", externalShipmentMessage);
            }
            var shipmentRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "shipment",
                items: shipmentLoadResponse.Items);

            this.appDB.Update(shipmentRequestUpdate);
            #endregion UpdateByRecord

            int count = shipmentRequestUpdate.Items.Count;

            return (count, infobar);
        }
        public (int Count, string Infobar) UpdateExternalCarrierShipmentStatus(decimal? shipmentID, char externalCarrierShipmentStatus, string externalShipmentMessage)
        {
            string infobar = "";

            #region CRUD LoadToRecord
            var shipmentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {

                {"external_carrier_shipment_status","shipment.external_carrier_shipment_status"},
                {"external_shipment_message","shipment.external_shipment_message"}
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
            if (shipmentLoadResponse.Items.Count > 0)
            {
                shipmentLoadResponse.Items[0].SetValue<char>("external_carrier_shipment_status", externalCarrierShipmentStatus);
                shipmentLoadResponse.Items[0].SetValue<string>("external_shipment_message", externalShipmentMessage);
            }
            var shipmentRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "shipment",
                items: shipmentLoadResponse.Items);

            this.appDB.Update(shipmentRequestUpdate);
            #endregion UpdateByRecord

            int count = shipmentRequestUpdate.Items.Count;

            return (count, infobar);
        }

        #endregion

    }
}
