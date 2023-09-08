//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReceivableTransactionHdrViews.cs

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
	[IDOExtensionClass("ESBReceivableTransactionHdrViews")]
	public class ESBReceivableTransactionHdrViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBReceivableTransactionSp(string Customer,
		                                          string ActionCode,
		                                          string BilltoCustomer,
		                                          decimal? Receievablebaseamount,
		                                          string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBReceivableTransactionExt = new LoadESBReceivableTransactionFactory().Create(appDb);
				
				int Severity = iLoadESBReceivableTransactionExt.LoadESBReceivableTransactionSp(Customer,
				                                                                               ActionCode,
				                                                                               BilltoCustomer,
				                                                                               Receievablebaseamount,
				                                                                               Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReceivableTransactionHdrSp(string CustNum,
		string invNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReceivableTransactionHdrExt = new CLM_ESBReceivableTransactionHdrFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReceivableTransactionHdrExt.CLM_ESBReceivableTransactionHdrSp(CustNum,
				invNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
