//PROJECT NAME: ReportExt
//CLASS NAME: SLTransferOrderShipPickListReport.cs

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
    [IDOExtensionClass("SLTransferOrderShipPickListReport")]
    public class SLTransferOrderShipPickListReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransferOrderShipPickListSp([Optional] string BegTrnNum,
		                                                 [Optional] string EndTrnNum,
		                                                 [Optional] DateTime? BegShipDate,
		                                                 [Optional] short? BegShipDateOffset,
		                                                 [Optional] DateTime? EndShipDate,
		                                                 [Optional] short? EndShipDateOffset,
		                                                 [Optional] DateTime? PostDate,
		                                                 [Optional] short? PostDateOffset,
		                                                 [Optional, DefaultParameterValue((byte)0)] byte? TRNOrderText,
		[Optional, DefaultParameterValue((byte)0)] byte? TRNitemNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrSerialNumbers,
		[Optional, DefaultParameterValue((byte)0)] byte? ListByLoc,
		[Optional, DefaultParameterValue((byte)0)] byte? PostMatlIssues,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintBc,
		[Optional, DefaultParameterValue((byte)0)] byte? Pickwarn,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)1)] byte? PProcess,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional] decimal? UserId,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_TransferOrderShipPickListExt = new Rpt_TransferOrderShipPickListFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_TransferOrderShipPickListExt.Rpt_TransferOrderShipPickListSp(BegTrnNum,
				                                                                               EndTrnNum,
				                                                                               BegShipDate,
				                                                                               BegShipDateOffset,
				                                                                               EndShipDate,
				                                                                               EndShipDateOffset,
				                                                                               PostDate,
				                                                                               PostDateOffset,
				                                                                               TRNOrderText,
				                                                                               TRNitemNotes,
				                                                                               PrSerialNumbers,
				                                                                               ListByLoc,
				                                                                               PostMatlIssues,
				                                                                               PrintBc,
				                                                                               Pickwarn,
				                                                                               DisplayHeader,
				                                                                               PProcess,
				                                                                               ShowInternal,
				                                                                               ShowExternal,
				                                                                               UserId,
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
