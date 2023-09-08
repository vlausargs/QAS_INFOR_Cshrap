//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReceivableTrackerHeaderViews.cs

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
	[IDOExtensionClass("ESBReceivableTrackerHeaderViews")]
	public class ESBReceivableTrackerHeaderViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReceivableTrackerHeaderSp(string CustomerPartyID,
		string Invoice,
		int? Sequence,
        string ArTranType,
        string BankCode,
        string ArpmtType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReceivableTrackerHeaderExt = new CLM_ESBReceivableTrackerHeaderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReceivableTrackerHeaderExt.CLM_ESBReceivableTrackerHeaderSp(CustomerPartyID,
				Invoice,
				Sequence,
                ArTranType,
                BankCode,
                ArpmtType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
