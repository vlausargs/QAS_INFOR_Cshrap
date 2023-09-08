using CSI.DataCollection;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemNonNettableLocationForWarehouse
    {
        void CreateItemNonNetLocBasedOnWarehouse(string item, string whse, string nonNetLoc);
    }

    public class ItemNonNettableLocationForWarehouse : IItemNonNettableLocationForWarehouse
    {
        readonly IItemWarehouseCRUD iItemWarehouseCRUD;
        readonly IItemLocAdd iItemLocAdd;

        public ItemNonNettableLocationForWarehouse(IItemWarehouseCRUD iItemWarehouseCRUD,
            IItemLocAdd iItemLocAdd)
        {
            this.iItemWarehouseCRUD = iItemWarehouseCRUD;
            this.iItemLocAdd = iItemLocAdd;
        }

        public void CreateItemNonNetLocBasedOnWarehouse(
            string item,
            string whse,
            string nonNetLoc)
        {
            int severity;
            string infobar;

            if (!iItemWarehouseCRUD.IsExistItemwhse(item, whse))
                iItemWarehouseCRUD.InsertItemwhse(item, whse);
            else
            {
                (int? ReturnCode, _, string Infobar) = iItemLocAdd.ItemLocAddSp(
                    Whse: whse,
                    Item: item,
                    Loc: nonNetLoc,
                    UcFlag: 0,
                    UnitCost: 0,
                    MatlCost: 0,
                    LbrCost: 0,
                    FovhdCost: 0,
                    VovhdCost: 0,
                    OutCost: 0,
                    SetPermFlag: 1,
                    MrbFlagValue: 1);
                severity = ReturnCode ?? 0;
                infobar = Infobar;

                if (severity != 0)
                    throw new System.Exception(infobar);
            }
        }
    }
}
