using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.CRUD.Reporting
{
    public class ProfileShipmentProFormaInvoiceCRUD : IProfileShipmentProFormaInvoiceCRUD
    {
        private readonly IApplicationDB _appDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;

        public ProfileShipmentProFormaInvoiceCRUD(IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            _appDB = appDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public ICollectionLoadResponse GetProfiles(decimal? shipmentStarting = null,
            decimal? shipmentEnding = null,
            string customerStarting = null,
            string customerEnding = null,
            int? shipToStarting = null,
            int? shipToEnding = null,
            DateTime? pickupDateStarting = null,
            DateTime? pickupDateEnding = null)
        {
            string fromClauseCmd = @"INNER JOIN shipment shipment ON shipment.shipment_id = shipment_seq.shipment_id
                INNER JOIN shipment_line shipment_line ON shipment_line.shipment_id = shipment_seq.shipment_id
                    AND shipment_line.shipment_line = shipment_seq.shipment_line
                LEFT JOIN DocProfileCustomer dpc ON dpc.CustNum = shipment.cust_num
                    AND dpc.CustSeq = shipment.cust_seq
                    AND dpc.RptName = 'Shipment Pro Forma Invoice Report'
                    AND dpc.active = 1
                LEFT JOIN customer(NOLOCK) customer ON shipment.cust_num = customer.cust_num
                    AND customer.cust_seq = 0";
            string whereClauseCmd = @"shipment.shipment_id BETWEEN {0} AND {1}
                AND customer.cust_num BETWEEN {2} AND {3}
                AND shipment.cust_seq BETWEEN {4} AND {5}
                AND ISNULL(shipment.pickup_date, dbo.LowDate()) BETWEEN {6} AND {7}";
            string orderByClauseCmd = @"shipment.shipment_id";
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"ShipmentId","shipment.shipment_id"},
                    {"CustNum","shipment.cust_num"},
                    {"CustSeq","shipment.cust_seq"},
                    {"IsProfileExisted","CASE WHEN dpc.RowPointer IS NOT NULL THEN 1 ELSE 0 END"},
                    {"NumCopies","CASE WHEN dpc.RowPointer IS NOT NULL THEN dpc.NumCopies ELSE NULL END"},
                    {"Method","CASE WHEN dpc.RowPointer IS NOT NULL THEN dpc.Method ELSE NULL END"},
                    {"Destination","CASE WHEN dpc.RowPointer IS NOT NULL THEN dpc.Destination ELSE NULL END"},
                    {"CoverSheetContact","dpc.CoverSheetContact"},
                    {"CoverSheetCompany","dpc.CoverSheetCompany"},
                    {"LangCode","customer.lang_code"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "shipment_seq",
                fromClause: _collectionLoadRequestFactory.Clause(fromClauseCmd),
                whereClause: _collectionLoadRequestFactory.Clause(whereClauseCmd,
                    shipmentStarting,
                    shipmentEnding,
                    customerStarting,
                    customerEnding,
                    shipToStarting,
                    shipToEnding,
                    pickupDateStarting,
                    pickupDateStarting),
                orderByClause: _collectionLoadRequestFactory.Clause(orderByClauseCmd));
            return _appDB.Load(request);
        }
    }

    public interface IProfileShipmentProFormaInvoiceCRUD
    {
        ICollectionLoadResponse GetProfiles(decimal? shipmentStarting = null,
            decimal? shipmentEnding = null,
            string customerStarting = null,
            string customerEnding = null,
            int? shipToStarting = null,
            int? shipToEnding = null,
            DateTime? pickupDateStarting = null,
            DateTime? pickupDateEnding = null);
    }
}