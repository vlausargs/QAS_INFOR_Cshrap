namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemNonNettableLocation
    {
        string GetItemNonNetLoc(string item, string warehouse);
    }

    public class ItemNonNettableLocation : IItemNonNettableLocation
    {
        readonly IExternalWarehouse iExternalWarehouse;
        readonly IItemLocationCRUD iItemLocationCRUD;
        readonly IWarehouseDefaultNonNettableLocation iWarehouseDefaultNonNettableLocation;
        readonly IItemNonNettableLocationForWarehouse iItemNonNettableLocationForWarehouse;

        public ItemNonNettableLocation(IExternalWarehouse iExternalWarehouse,
            IItemLocationCRUD iItemLocationCRUD,
            IWarehouseDefaultNonNettableLocation iWarehouseDefaultNonNettableLocation,
            IItemNonNettableLocationForWarehouse iItemNonNettableLocationForWarehouse)
        {
            this.iExternalWarehouse = iExternalWarehouse;
            this.iItemLocationCRUD = iItemLocationCRUD;
            this.iWarehouseDefaultNonNettableLocation = iWarehouseDefaultNonNettableLocation;
            this.iItemNonNettableLocationForWarehouse = iItemNonNettableLocationForWarehouse;
        }

        public string GetItemNonNetLoc(string item, string warehouse)
        {
            string whse = iExternalWarehouse.ConvertExternalWhseToLocalWhse(warehouse);
            string itemNonNetLoc = iItemLocationCRUD.GetItemNonNetLoc(item, whse);
            string whseDefNonNetLoc;

            if (itemNonNetLoc == null)
            {
                whseDefNonNetLoc = iWarehouseDefaultNonNettableLocation.CheckWhseDefNonNetLoc(whse);
                iItemNonNettableLocationForWarehouse.CreateItemNonNetLocBasedOnWarehouse(item, whse, whseDefNonNetLoc);
                return whseDefNonNetLoc;
            }

            return itemNonNetLoc;
        }
    }
}
