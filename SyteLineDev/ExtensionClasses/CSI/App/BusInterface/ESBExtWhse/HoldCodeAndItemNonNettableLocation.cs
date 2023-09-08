namespace CSI.BusInterface.ESBExtWhse
{
    public interface IHoldCodeAndItemNonNettableLocation
    {
            string GetItemNonNetLocWhenHoldCodeExists(string item, string warehouse, string holdcode);
    }

    public class HoldCodeAndItemNonNettableLocation : IHoldCodeAndItemNonNettableLocation
    {
        readonly IExternalHoldCodeCRUD iExternalHoldCodeCRUD;
        readonly IItemNonNettableLocation iItemNonNettableLocation;

        public HoldCodeAndItemNonNettableLocation(IExternalHoldCodeCRUD iExternalHoldCodeCRUD,
            IItemNonNettableLocation iItemNonNettableLocation)
        {
            this.iExternalHoldCodeCRUD = iExternalHoldCodeCRUD;
            this.iItemNonNettableLocation = iItemNonNettableLocation;
        }

        public string GetItemNonNetLocWhenHoldCodeExists(
            string item,
            string warehouse,
            string holdcode)
        {
            string itemNonNetLoc = null;

            if (iExternalHoldCodeCRUD.IsExistInExtWhseHoldCode(holdcode))
                return iItemNonNettableLocation.GetItemNonNetLoc(item, warehouse);

            return itemNonNetLoc;
        }
    }
}
