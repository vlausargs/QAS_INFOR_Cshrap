//PROJECT NAME: ProductExt
//CLASS NAME: SLBatchProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
	[IDOExtensionClass("SLBatchProd")]
	public class SLBatchProd : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetJobDemandIdSp(string PDemandType,
		[Optional] string DemandIDFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetJobDemandIdExt = new CLM_GetJobDemandIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetJobDemandIdExt.CLM_GetJobDemandIdSp(PDemandType,
				DemandIDFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateJobDemandIdSp(string PDemandType,
		string DemandID,
		ref string Job,
		ref int? Suffix,
		ref string Item,
		ref decimal? QtyReleased,
		ref DateTime? EndDate,
		ref string PSNum,
		ref string Ppjob)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateJobDemandIdExt = new ValidateJobDemandIdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateJobDemandIdExt.ValidateJobDemandIdSp(PDemandType,
				DemandID,
				Job,
				Suffix,
				Item,
				QtyReleased,
				EndDate,
				PSNum,
				Ppjob);
				
				int Severity = result.ReturnCode.Value;
				Job = result.Job;
				Suffix = result.Suffix;
				Item = result.Item;
				QtyReleased = result.QtyReleased;
				EndDate = result.EndDate;
				PSNum = result.PSNum;
				Ppjob = result.Ppjob;
				return Severity;
			}
		}
	}
}
