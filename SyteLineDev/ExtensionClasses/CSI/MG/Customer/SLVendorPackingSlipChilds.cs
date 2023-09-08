//PROJECT NAME: CustomerExt
//CLASS NAME: SLVendorPackingSlipChilds.cs

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
    [IDOExtensionClass("SLVendorPackingSlipChilds")]
    public class SLVendorPackingSlipChilds : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXPackSlipQtyValidSp(decimal? QtyRequired,
                                            decimal? QtyToPack,
                                            string TPckCall,
                                            ref string Warning,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXPackSlipQtyValidExt = new SSSRMXPackSlipQtyValidFactory().Create(appDb);

                int Severity = iSSSRMXPackSlipQtyValidExt.SSSRMXPackSlipQtyValidSp(QtyRequired,
                                                                                   QtyToPack,
                                                                                   TPckCall,
                                                                                   ref Warning,
                                                                                   ref Infobar);

                return Severity;
            }
        }




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXVendorPckSlipLoadSp(string TPckCall,
		                                           string RefType,
		                                           string VendNum,
		                                           string RefNum,
		                                           string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRMXVendorPackingSlipLoadExt = new SSSRMXVendorPackingSlipLoadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRMXVendorPackingSlipLoadExt.SSSRMXVendorPackingSlipLoadSp(TPckCall,
				                                                                           RefType,
				                                                                           VendNum,
				                                                                           RefNum,
				                                                                           Whse);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXCreatePckItemSp(string TPckCall,
		int? PackNum,
		string RefNum,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? RefLine,
		int? RefRelease,
		string RefType,
		string Item,
		string UM,
		string description,
		decimal? qtyordered,
		decimal? qtytopack,
		decimal? qtytopackconv,
		string vendRef,
		string VendNum,
		Guid? RowPointer,
		string ProcessId,
		int? PackLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRMXCreatePckItemExt = new SSSRMXCreatePckItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRMXCreatePckItemExt.SSSRMXCreatePckItemSp(TPckCall,
				PackNum,
				RefNum,
				ShipCode,
				QtyPackages,
				Weight,
				PackDate,
				Whse,
				RefLine,
				RefRelease,
				RefType,
				Item,
				UM,
				description,
				qtyordered,
				qtytopack,
				qtytopackconv,
				vendRef,
				VendNum,
				RowPointer,
				ProcessId,
				PackLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
