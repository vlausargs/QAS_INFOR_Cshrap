//PROJECT NAME: MG
//CLASS NAME: SLFixedAssetMovementReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLFixedAssetMovementReport")]
	public class SLFixedAssetMovementReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FAMovementSp([Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] string ClassCodeStarting,
		[Optional] string ClassCodeEnding,
		[Optional] string ExOptdfFaType,
		[Optional] string ExOptdfFaStat,
		[Optional] string AssetStarting,
		[Optional] string AssetEnding,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string LocationStarting,
		[Optional] string LocationEnding,
		[Optional] string DepartmentStarting,
		[Optional] string DepartmentEnding,
		[Optional] string SortBy,
		[Optional] int? STransDateOffset,
		[Optional] int? ETransDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_FAMovementExt = new Rpt_FAMovementFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_FAMovementExt.Rpt_FAMovementSp(TransDateStarting,
				TransDateEnding,
				ClassCodeStarting,
				ClassCodeEnding,
				ExOptdfFaType,
				ExOptdfFaStat,
				AssetStarting,
				AssetEnding,
				VendorStarting,
				VendorEnding,
				LocationStarting,
				LocationEnding,
				DepartmentStarting,
				DepartmentEnding,
				SortBy,
				STransDateOffset,
				ETransDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
