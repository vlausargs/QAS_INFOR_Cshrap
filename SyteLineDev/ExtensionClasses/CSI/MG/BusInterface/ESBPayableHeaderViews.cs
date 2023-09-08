//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBPayableHeaderViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBPayableHeaderViews")]
	public class ESBPayableHeaderViews : ExtensionClassBase
	{






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBPayableHeaderSp(string SupplierPartyID,
		int? Voucher)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBPayableHeaderExt = new CLM_ESBPayableHeaderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBPayableHeaderExt.CLM_ESBPayableHeaderSp(SupplierPartyID,
				Voucher);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPayableTransactionSp(string Vendor,
		string ActionCode,
		string RemittoVendor,
		decimal? PayableAmount,
		string VendorCurrCode,
		DateTime? DocumentDateTime,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBPayableTransactionExt = new LoadESBPayableTransactionFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBPayableTransactionExt.LoadESBPayableTransactionSp(Vendor,
				ActionCode,
				RemittoVendor,
				PayableAmount,
				VendorCurrCode,
				DocumentDateTime,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadPayableTransactionSp(string Vendor,
		string ActionCode,
		string RemittoVendor,
		decimal? PayableAmount,
		string VendorCurrCode,
		DateTime? DocumentDateTime,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBPayableTransactionExt = new LoadESBPayableTransactionFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBPayableTransactionExt.LoadESBPayableTransactionSp(Vendor,
				ActionCode,
				RemittoVendor,
				PayableAmount,
				VendorCurrCode,
				DocumentDateTime,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
