//PROJECT NAME: CustomerExt
//CLASS NAME: SLVendorPackingSlips.cs

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
    [IDOExtensionClass("SLVendorPackingSlips")]
    public class SLVendorPackingSlips : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXVendorPckSlipHdrLoadSp(string TPckCall,
		                                              byte? RefTypeM,
		                                              byte? RefTypeP,
		                                              string BeginVendNum,
		                                              string EndVendNum,
		                                              string BeginRefNum,
		                                              string EndRefNum,
		                                              string Whse,
		                                              [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRMXVendorPckSlipHdrLoadExt = new SSSRMXVendorPckSlipHdrLoadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRMXVendorPckSlipHdrLoadExt.SSSRMXVendorPckSlipHdrLoadSp(TPckCall,
				                                                                         RefTypeM,
				                                                                         RefTypeP,
				                                                                         BeginVendNum,
				                                                                         EndVendNum,
				                                                                         BeginRefNum,
				                                                                         EndRefNum,
				                                                                         Whse,
				                                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXDummySp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRMXDummyExt = new SSSRMXDummyFactory().Create(appDb);
				
				var result = iSSSRMXDummyExt.SSSRMXDummySp();
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TranUdSp(int? LasttranKey,
		ref decimal? LastTran,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTranUdExt = new TranUdFactory().Create(appDb);
				
				var result = iTranUdExt.TranUdSp(LasttranKey,
				LastTran,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				LastTran = result.LastTran;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
