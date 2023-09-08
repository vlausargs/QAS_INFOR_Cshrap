//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBJobOperationViews.cs

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
	[IDOExtensionClass("ESBJobOperationViews")]
	public class ESBJobOperationViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBJobOperationSp(string Job,
		int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBJobOperationExt = new CLM_ESBJobOperationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBJobOperationExt.CLM_ESBJobOperationSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBJobOperationSp(string Job,
		int? Suffix,
		string OperationID,
		string ActionExpression,
		DateTime? StartDate,
		DateTime? EndDate,
		string RunTimeDurationPerUnit,
		string QueueDuration,
		string QueueOverlapDuration,
		string MoveDuration,
		string FixedDuration,
		decimal? RejectPercent,
		string BackFlushInicator,
		string WC,
		string LaborSetupTimeDuration,
		ref int? OperNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBJobOperationExt = new LoadESBJobOperationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBJobOperationExt.LoadESBJobOperationSp(Job,
				Suffix,
				OperationID,
				ActionExpression,
				StartDate,
				EndDate,
				RunTimeDurationPerUnit,
				QueueDuration,
				QueueOverlapDuration,
				MoveDuration,
				FixedDuration,
				RejectPercent,
				BackFlushInicator,
				WC,
				LaborSetupTimeDuration,
				OperNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperNum = result.OperNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
