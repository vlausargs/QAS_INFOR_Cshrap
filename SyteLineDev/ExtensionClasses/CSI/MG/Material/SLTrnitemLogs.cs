//PROJECT NAME: MaterialExt
//CLASS NAME: SLTrnitemLogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLTrnitemLogs")]
	public class SLTrnitemLogs : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTrnLineItemLogEntriesSp(DateTime? SActivityDate,
		DateTime? EActivityDate,
		string STrnNum,
		string ETrnNum,
		int? STrnLine,
		int? ETrnLine,
		int? CreateInitial,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteTrnLineItemLogEntriesExt = new DeleteTrnLineItemLogEntriesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteTrnLineItemLogEntriesExt.DeleteTrnLineItemLogEntriesSp(SActivityDate,
				EActivityDate,
				STrnNum,
				ETrnNum,
				STrnLine,
				ETrnLine,
				CreateInitial,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetListSourceForTrnLinesSp([Optional] string STrnNum,
		[Optional] string ETrnNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetListSourceForTrnLinesExt = new GetListSourceForTrnLinesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetListSourceForTrnLinesExt.GetListSourceForTrnLinesSp(STrnNum,
				ETrnNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
