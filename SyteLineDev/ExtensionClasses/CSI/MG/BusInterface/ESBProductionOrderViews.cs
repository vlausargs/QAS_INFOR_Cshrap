//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBProductionOrderViews.cs

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
	[IDOExtensionClass("ESBProductionOrderViews")]
	public class ESBProductionOrderViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBProductionOrderSp(string Job,
		[Optional] int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBProductionOrderExt = new CLM_ESBProductionOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBProductionOrderExt.CLM_ESBProductionOrderSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBProductionOrderSp(string DerBODID,
		string ActionExpression,
		string Description,
		DateTime? CreateDate,
		DateTime? DueDateTime,
		DateTime? EarliestStartDateTime,
		DateTime? RecordDate,
		string Rework,
		string Status,
		ref string Job,
		ref int? Suffix,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBProductionOrderExt = new LoadESBProductionOrderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBProductionOrderExt.LoadESBProductionOrderSp(DerBODID,
				ActionExpression,
				Description,
				CreateDate,
				DueDateTime,
				EarliestStartDateTime,
				RecordDate,
				Rework,
				Status,
				Job,
				Suffix,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Job = result.Job;
				Suffix = result.Suffix;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
