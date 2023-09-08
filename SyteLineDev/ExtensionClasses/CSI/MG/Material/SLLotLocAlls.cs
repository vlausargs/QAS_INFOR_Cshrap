//PROJECT NAME: MaterialExt
//CLASS NAME: SLLotLocAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLLotLocAlls")]
    public class SLLotLocAlls : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SiteLotValidSp(string pItem,
                                          string pLot,
                                          string pTrnLoc,
                                          string pWhse,
                                          string pSite,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSiteLotValidExt = new SiteLotValidFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSiteLotValidExt.SiteLotValidSp(pItem,
                                                               pLot,
                                                               pTrnLoc,
                                                               pWhse,
                                                               pSite,
                                                               ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TrnShipLotReferenceSp(string Item,
		string TOSite,
		string RefNum,
		int? RefLineSuf,
		string Whse,
		string Loc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTrnShipLotReferenceExt = new TrnShipLotReferenceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTrnShipLotReferenceExt.TrnShipLotReferenceSp(Item,
				TOSite,
				RefNum,
				RefLineSuf,
				Whse,
				Loc);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
