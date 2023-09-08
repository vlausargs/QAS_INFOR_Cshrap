//PROJECT NAME: CustomerExt
//CLASS NAME: SLVendToShips.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLVendToShips")]
    public class SLVendToShips : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXShipDeleteSp(string VendNum,
                                      string RefType,
                                      string RefNum,
                                      int? RefLine,
                                      int? RefRelease,
                                      decimal? Seq,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXShipDeleteExt = new SSSRMXShipDeleteFactory().Create(appDb);

                int Severity = iSSSRMXShipDeleteExt.SSSRMXShipDeleteSp(VendNum,
                                                                       RefType,
                                                                       RefNum,
                                                                       RefLine,
                                                                       RefRelease,
                                                                       Seq,
                                                                       ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXShipOneSp(string RmaNum,
                                   short? RmaLine,
                                   int? TransNum,
                                   decimal? Seq,
                                   DateTime? ShipDate,
                                   decimal? QtyToShipConv,
                                   string Whse,
                                   string Loc,
                                   string Lot,
                                   string UM,
                                   string TransNat,
                                   string Delterm,
                                   string EcCode,
                                   string Transport,
                                   string Origin,
                                   string CommCode,
                                   decimal? SupplQty,
                                   decimal? ExportValue,
                                   decimal? UnitWeight,
                                   int? ConsNum,
                                   string ProcessInd,
                                   decimal? Price,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXShipOneExt = new SSSRMXShipOneFactory().Create(appDb);

                int Severity = iSSSRMXShipOneExt.SSSRMXShipOneSp(RmaNum,
                                                                 RmaLine,
                                                                 TransNum,
                                                                 Seq,
                                                                 ShipDate,
                                                                 QtyToShipConv,
                                                                 Whse,
                                                                 Loc,
                                                                 Lot,
                                                                 UM,
                                                                 TransNat,
                                                                 Delterm,
                                                                 EcCode,
                                                                 Transport,
                                                                 Origin,
                                                                 CommCode,
                                                                 SupplQty,
                                                                 ExportValue,
                                                                 UnitWeight,
                                                                 ConsNum,
                                                                 ProcessInd,
                                                                 Price,
                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXShipRevOneSp(Guid? ToShipRowPointer,
                                      DateTime? ShipDate,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXShipRevOneExt = new SSSRMXShipRevOneFactory().Create(appDb);

                int Severity = iSSSRMXShipRevOneExt.SSSRMXShipRevOneSp(ToShipRowPointer,
                                                                       ShipDate,
                                                                       ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXShipLoadSp(string VendNum,
		                                  byte? Reverse,
		                                  ref string Infobar,
		                                  [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRMXShipLoadExt = new SSSRMXShipLoadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRMXShipLoadExt.SSSRMXShipLoadSp(VendNum,
				                                                 Reverse,
				                                                 Infobar,
				                                                 FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
