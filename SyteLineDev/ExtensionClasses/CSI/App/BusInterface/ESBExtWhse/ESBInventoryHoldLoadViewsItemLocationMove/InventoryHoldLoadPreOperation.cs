using System;


namespace CSI.BusInterface.ESBExtWhse
{
    public interface IInventoryHoldLoadPreOperation
    {
        (string whse, DateTime tDate, string fromLoc, string toLoc, string lot) ValidateAndPrepareDataForItemMovement(string item, string warehouse, DateTime? transactionDate, string newHoldCode);
    }

    public class InventoryHoldLoadPreOperation : IInventoryHoldLoadPreOperation
    {

        readonly IItemNonNettableLocation iItemNonNettableLocation;
        readonly IItemLocationCRUD iItemLocationCRUD;
        readonly ILotAndSNTrackedItem iExternalTrackedItems;
        readonly ITransactionDate iTransactionDate;
        readonly IExternalWarehouse iExternalWarehouse;

        public InventoryHoldLoadPreOperation(IItemNonNettableLocation iItemNonNettableLocation, IItemLocationCRUD iItemLocationCRUD, ILotAndSNTrackedItem iExternalTrackedItems, ITransactionDate iTransactionDate, IExternalWarehouse iExternalWarehouse)
        {
            this.iItemNonNettableLocation = iItemNonNettableLocation;
            this.iItemLocationCRUD = iItemLocationCRUD;
            this.iExternalTrackedItems = iExternalTrackedItems;
            this.iTransactionDate = iTransactionDate;
            this.iExternalWarehouse = iExternalWarehouse;
        }

        public (string whse, DateTime tDate, string fromLoc, string toLoc, string lot) ValidateAndPrepareDataForItemMovement(string item, string warehouse, DateTime? transactionDate, string newHoldCode)
        {
            string whse = iExternalWarehouse.ConvertExternalWhseToLocalWhse(warehouse);
            DateTime tDate = iTransactionDate.GetSQLDateWhenNull(transactionDate);
            string itemNonNettableLoc = iItemNonNettableLocation.GetItemNonNetLoc(item, whse);
            string itemNettableLoc = iItemLocationCRUD.GetItemNetLoc(item, whse);
            string fromLoc = newHoldCode == "NonNettable" ? itemNettableLoc : itemNonNettableLoc;
            string toLoc = newHoldCode == "NonNettable" ? itemNonNettableLoc : itemNettableLoc;
            string lot = iExternalTrackedItems.GetLotAndSetCheckLocFlag(item);

            return (whse, tDate, fromLoc, toLoc, lot);
        }
    }
}
