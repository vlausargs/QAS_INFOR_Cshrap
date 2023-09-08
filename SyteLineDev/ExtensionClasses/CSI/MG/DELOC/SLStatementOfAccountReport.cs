//PROJECT NAME: DELOCExt
//CLASS NAME: SLStatementOfAccountReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting.Germany;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DELOC
{
	[IDOExtensionClass("SLStatementOfAccountReport")]
	public class SLStatementOfAccountReport : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_StatementofAccountSp([Optional, DefaultParameterValue((byte)0)] byte? PrintResponseLetter,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintZeroBalCustVend,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)0)] byte? ShowDetail,
		[Optional] DateTime? CutOffDate,
		[Optional] short? CutOffDateOffset,
		[Optional, DefaultParameterValue((byte)0)] byte? VendorSelected,
		[Optional] string FromVendNum,
		[Optional] string ToVendNum,
		[Optional, DefaultParameterValue((byte)0)] byte? CustomerSelected,
		[Optional] string FromCustNum,
		[Optional] string ToCustNum,
		[Optional] ref string Infobar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_StatementofAccountExt = new Rpt_StatementofAccountFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_StatementofAccountExt.Rpt_StatementofAccountSp(PrintResponseLetter,
				                                                                 PrintZeroBalCustVend,
				                                                                 DisplayHeader,
				                                                                 ShowDetail,
				                                                                 CutOffDate,
				                                                                 CutOffDateOffset,
				                                                                 VendorSelected,
				                                                                 FromVendNum,
				                                                                 ToVendNum,
				                                                                 CustomerSelected,
				                                                                 FromCustNum,
				                                                                 ToCustNum,
				                                                                 Infobar,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
