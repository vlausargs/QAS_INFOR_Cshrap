//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSSDLineViews.cs

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
	[IDOExtensionClass("ESBSSDLineViews")]
	public class ESBSSDLineViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSSDLineSp(string TransIndicator,
		string RefType,
		DateTime? StartPeriod,
		DateTime? EndPeriod,
		string StartCust,
		string EndCust,
		string StartVend,
		string EndVend,
		string StartWhse,
		string EndWhse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSSDLineExt = new CLM_ESBSSDLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSSDLineExt.CLM_ESBSSDLineSp(TransIndicator,
				RefType,
				StartPeriod,
				EndPeriod,
				StartCust,
				EndCust,
				StartVend,
				EndVend,
				StartWhse,
				EndWhse);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
