//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceOverallEquipmentEffectivenessReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLResourceOverallEquipmentEffectivenessReport")]
	public class SLResourceOverallEquipmentEffectivenessReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceOverallEquipmentEffectivenessSp([Optional] string RgrpType,
		[Optional] string StartResourceGroup,
		[Optional] string EndResourceGroup,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceOverallEquipmentEffectivenessExt = new Rpt_ResourceOverallEquipmentEffectivenessFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceOverallEquipmentEffectivenessExt.Rpt_ResourceOverallEquipmentEffectivenessSp(RgrpType,
				StartResourceGroup,
				EndResourceGroup,
				StartDate,
				EndDate,
				StartDateOffset,
				EndDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
