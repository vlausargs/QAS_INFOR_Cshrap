//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBJobMatlViews.cs

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
	[IDOExtensionClass("ESBJobMatlViews")]
	public class ESBJobMatlViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBJobMatlSp(string Job,
		                            short? Suffix,
		                            int? OperNum,
		                            string ActionExpression,
		                            string InputItem,
		                            decimal? InputPlanQty,
		                            string InputISOUM,
		                            string InputDescription,
		                            string InputDrawingNumber,
		                            string InputFixedQuantity,
		                            string OutputItem,
		                            decimal? OutputPlanQty,
		                            string OutputISOUM,
		                            string OutputDescription,
		                            string OutputDrawingNumber,
		                            string OutputFixedQuantity,
		                            string OutputItemType,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBJobMatlExt = new LoadESBJobMatlFactory().Create(appDb);
				
				int Severity = iLoadESBJobMatlExt.LoadESBJobMatlSp(Job,
				                                                   Suffix,
				                                                   OperNum,
				                                                   ActionExpression,
				                                                   InputItem,
				                                                   InputPlanQty,
				                                                   InputISOUM,
				                                                   InputDescription,
				                                                   InputDrawingNumber,
				                                                   InputFixedQuantity,
				                                                   OutputItem,
				                                                   OutputPlanQty,
				                                                   OutputISOUM,
				                                                   OutputDescription,
				                                                   OutputDrawingNumber,
				                                                   OutputFixedQuantity,
				                                                   OutputItemType,
				                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBJobMatlSp(string Job,
		int? Suffix,
		int? OperNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBJobMatlExt = new CLM_ESBJobMatlFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBJobMatlExt.CLM_ESBJobMatlSp(Job,
				Suffix,
				OperNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
