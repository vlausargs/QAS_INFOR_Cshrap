//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReceivableTrackerLineViews.cs

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
	[IDOExtensionClass("ESBReceivableTrackerLineViews")]
	public class ESBReceivableTrackerLineViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReceivableTrackerLineSp(string CustomerPartyID,
		string Invoice,
		int? Sequence,
        string ArTranType,
        string BankCode,
        string ArmptType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReceivableTrackerLineExt = new CLM_ESBReceivableTrackerLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReceivableTrackerLineExt.CLM_ESBReceivableTrackerLineSp(CustomerPartyID,
				Invoice,
				Sequence,
                ArTranType,
                BankCode,
                ArmptType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
