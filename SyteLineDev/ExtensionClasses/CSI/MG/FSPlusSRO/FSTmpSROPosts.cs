//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSTmpSROPosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSTmpSROPosts")]
	public class FSTmpSROPosts : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransPostUtilCleanupSp([Optional] Guid? PSessionID,
		[Optional] decimal? PTaskID,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransPostUtilCleanupExt = new SSSFSSROTransPostUtilCleanupFactory().Create(appDb);
				
				var result = iSSSFSSROTransPostUtilCleanupExt.SSSFSSROTransPostUtilCleanupSp(PSessionID,
				PTaskID,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransPostUtilSp([Optional, DefaultParameterValue(0)] int? Commit,
		[Optional, DefaultParameterValue(0)] int? Background,
		[Optional, DefaultParameterValue("A")] string Type,
		string StartSRONum,
		string EndSRONum,
		int? StartSROLine,
		int? EndSROLine,
		int? StartSROOper,
		int? EndSROOper,
		[Optional] string StartSROType,
		[Optional] string EndSROType,
		[Optional] DateTime? StartTransDate,
		[Optional] DateTime? EndTransDate,
		[Optional] int? StartTransDateOffset,
		[Optional] int? EndTransDateOffset,
		[Optional] string StartDept,
		[Optional] string EndDept,
		[Optional] string StartPartnerId,
		[Optional] string EndPartnerId,
		[Optional] string StartOperCode,
		[Optional] string EndOperCode,
		[Optional] string StartOperWhse,
		[Optional] string EndOperWhse,
		[Optional] string StartTransWhse,
		[Optional] string EndTransWhse,
		[Optional] string StartLoc,
		[Optional] string EndLoc,
		[Optional, DefaultParameterValue(1)] int? InclMatl,
		[Optional, DefaultParameterValue(1)] int? InclLabor,
		[Optional, DefaultParameterValue(1)] int? InclMisc,
		[Optional, DefaultParameterValue(1)] int? InclLineMatl,
		[Optional, DefaultParameterValue("CNWRLU")] string BillCodesList,
		[Optional, DefaultParameterValue("N")] string GenerateReport,
		[Optional, DefaultParameterValue("S")] string ReportOrderBy,
		[Optional] string RequestingUser,
		ref string InfoBar,
		[Optional] string StartDocumentNum,
		[Optional] string EndDocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransPostUtilExt = new SSSFSSROTransPostUtilFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransPostUtilExt.SSSFSSROTransPostUtilSp(Commit,
				Background,
				Type,
				StartSRONum,
				EndSRONum,
				StartSROLine,
				EndSROLine,
				StartSROOper,
				EndSROOper,
				StartSROType,
				EndSROType,
				StartTransDate,
				EndTransDate,
				StartTransDateOffset,
				EndTransDateOffset,
				StartDept,
				EndDept,
				StartPartnerId,
				EndPartnerId,
				StartOperCode,
				EndOperCode,
				StartOperWhse,
				EndOperWhse,
				StartTransWhse,
				EndTransWhse,
				StartLoc,
				EndLoc,
				InclMatl,
				InclLabor,
				InclMisc,
				InclLineMatl,
				BillCodesList,
				GenerateReport,
				ReportOrderBy,
				RequestingUser,
				InfoBar,
				StartDocumentNum,
				EndDocumentNum);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
