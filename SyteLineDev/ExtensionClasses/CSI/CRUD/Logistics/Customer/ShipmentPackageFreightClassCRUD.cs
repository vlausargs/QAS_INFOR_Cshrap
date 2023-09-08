using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public interface IShipmentPackageFreightClassCRUD
    {
        (int Count, string Infobar) UpdateFreightClass(decimal? ShipmentId, int? PackageId, string FreightClass);
    }
    public class ShipmentPackageFreightClassCRUD : IShipmentPackageFreightClassCRUD
    {
        IApplicationDB appDB;
        ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public ShipmentPackageFreightClassCRUD(IApplicationDB appDB, ICollectionUpdateRequestFactory collectionUpdateRequestFactory, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.appDB = appDB;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public (int Count, string Infobar) UpdateFreightClass(decimal? ShipmentId, int? PackageId, string FreightClass)
        {
            int count = 0;
            string infobar = "";
            #region CRUD LoadToRecord shipment_package
            var shipment_packageLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
            {"freight_class","freight_class"},
            },
            tableName: "shipment_package",
            loadForChange: true,
            lockingType: LockingType.UPDLock,
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("package_id = {0} AND shipment_id = {1}", PackageId, ShipmentId),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var shipment_packageLoadResponse = this.appDB.Load(shipment_packageLoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord shipment_package
            foreach (var shipment_packageItem in shipment_packageLoadResponse.Items)
            {
                shipment_packageItem.SetValue<int?>("freight_class", FreightClass);
            };

            var shipment_packageRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "shipment_package",
            items: shipment_packageLoadResponse.Items);

            this.appDB.Update(shipment_packageRequestUpdate);
            #endregion UpdateByRecord

            count = shipment_packageLoadResponse.Items.Count;

            return (count, infobar);
        }
    }
}
