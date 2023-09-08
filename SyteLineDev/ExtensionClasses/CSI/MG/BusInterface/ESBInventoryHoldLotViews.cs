//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBInventoryHoldLotViews.cs

using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.Data.RecordSets;
using CSI.BusInterface.ESBExtWhse;
using Microsoft.Extensions.DependencyInjection;
using CSI.Data.SQL;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBInventoryHoldLotViews")]
    public class ESBInventoryHoldLotViews : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBInventoryHoldLotSp(string Item,
        string Lot)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ESBInventoryHoldLotExt = new CLM_ESBInventoryHoldLotFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iCLM_ESBInventoryHoldLotExt.CLM_ESBInventoryHoldLotSp(Item,
                Lot);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void SetLot(string DerLotID)
        {
            var iESBInventoryHoldLoadViewsLotsExt = this.GetService<IESBInventoryHoldLoadViewsLots>();
            iESBInventoryHoldLoadViewsLotsExt.SetLot(DerLotID);
        }
    }
}
