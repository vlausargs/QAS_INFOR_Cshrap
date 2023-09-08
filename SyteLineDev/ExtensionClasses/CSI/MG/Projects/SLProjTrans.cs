//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.RecordSets;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Logistics.Customer;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjTrans")]
	public class SLProjTrans : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProjectCostingActivitySp([Optional] string ProjMgr,
		[Optional, DefaultParameterValue("M")] string PeriodType,
		[Optional] string FilterString,
		string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ProjectCostingActivityExt = new CLM_ProjectCostingActivityFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ProjectCostingActivityExt.CLM_ProjectCostingActivitySp(ProjMgr,
				PeriodType,
				FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVariableDateBucketsSp(string PeriodType,
		ref DateTime? PerStart,
		ref DateTime? PerEnd,
		ref DateTime? PeriodStart1,
		ref DateTime? PeriodStart2,
		ref DateTime? PeriodStart3,
		ref DateTime? PeriodStart4,
		ref DateTime? PeriodStart5,
		ref DateTime? PeriodStart6,
		ref DateTime? PeriodStart7,
		ref DateTime? PeriodStart8,
		ref DateTime? PeriodStart9,
		ref DateTime? PeriodStart10,
		ref DateTime? PeriodStart11,
		ref DateTime? PeriodStart12,
		ref DateTime? PeriodEnd1,
		ref DateTime? PeriodEnd2,
		ref DateTime? PeriodEnd3,
		ref DateTime? PeriodEnd4,
		ref DateTime? PeriodEnd5,
		ref DateTime? PeriodEnd6,
		ref DateTime? PeriodEnd7,
		ref DateTime? PeriodEnd8,
		ref DateTime? PeriodEnd9,
		ref DateTime? PeriodEnd10,
		ref DateTime? PeriodEnd11,
		ref DateTime? PeriodEnd12)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetVariableDateBucketsExt = new GetVariableDateBucketsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetVariableDateBucketsExt.GetVariableDateBucketsSp(PeriodType,
				PerStart,
				PerEnd,
				PeriodStart1,
				PeriodStart2,
				PeriodStart3,
				PeriodStart4,
				PeriodStart5,
				PeriodStart6,
				PeriodStart7,
				PeriodStart8,
				PeriodStart9,
				PeriodStart10,
				PeriodStart11,
				PeriodStart12,
				PeriodEnd1,
				PeriodEnd2,
				PeriodEnd3,
				PeriodEnd4,
				PeriodEnd5,
				PeriodEnd6,
				PeriodEnd7,
				PeriodEnd8,
				PeriodEnd9,
				PeriodEnd10,
				PeriodEnd11,
				PeriodEnd12);
				
				int Severity = result.ReturnCode.Value;
				PerStart = result.PerStart;
				PerEnd = result.PerEnd;
				PeriodStart1 = result.PeriodStart1;
				PeriodStart2 = result.PeriodStart2;
				PeriodStart3 = result.PeriodStart3;
				PeriodStart4 = result.PeriodStart4;
				PeriodStart5 = result.PeriodStart5;
				PeriodStart6 = result.PeriodStart6;
				PeriodStart7 = result.PeriodStart7;
				PeriodStart8 = result.PeriodStart8;
				PeriodStart9 = result.PeriodStart9;
				PeriodStart10 = result.PeriodStart10;
				PeriodStart11 = result.PeriodStart11;
				PeriodStart12 = result.PeriodStart12;
				PeriodEnd1 = result.PeriodEnd1;
				PeriodEnd2 = result.PeriodEnd2;
				PeriodEnd3 = result.PeriodEnd3;
				PeriodEnd4 = result.PeriodEnd4;
				PeriodEnd5 = result.PeriodEnd5;
				PeriodEnd6 = result.PeriodEnd6;
				PeriodEnd7 = result.PeriodEnd7;
				PeriodEnd8 = result.PeriodEnd8;
				PeriodEnd9 = result.PeriodEnd9;
				PeriodEnd10 = result.PeriodEnd10;
				PeriodEnd11 = result.PeriodEnd11;
				PeriodEnd12 = result.PeriodEnd12;
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
