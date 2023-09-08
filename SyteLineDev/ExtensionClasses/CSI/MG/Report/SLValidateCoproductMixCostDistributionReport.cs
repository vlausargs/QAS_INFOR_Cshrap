//PROJECT NAME: ReportExt
//CLASS NAME: SLValidateCoproductMixCostDistributionReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Material;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLValidateCoproductMixCostDistributionReport")]
	public class SLValidateCoproductMixCostDistributionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemValMixSp([Optional] string PProdMix,
		[Optional, DefaultParameterValue(1)] int? PPrintOperText,
		[Optional, DefaultParameterValue(0)] int? PPageBtwOper,
		[Optional, DefaultParameterValue(1)] int? PPrintMatlText,
		[Optional, DefaultParameterValue(0)] int? PDisRefFields,
		[Optional, DefaultParameterValue(0)] int? PDisEffDate,
		[Optional] DateTime? PEffectDate,
		[Optional, DefaultParameterValue(0)] int? ShowInternal,
		[Optional, DefaultParameterValue(0)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		string Infobar,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ItemValMixExt = new Rpt_ItemValMixFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ItemValMixExt.Rpt_ItemValMixSp(PProdMix,
				PPrintOperText,
				PPageBtwOper,
				PPrintMatlText,
				PDisRefFields,
				PDisEffDate,
				PEffectDate,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				Infobar,
				BGSessionId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
