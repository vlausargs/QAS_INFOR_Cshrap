//PROJECT NAME: AdminExt
//CLASS NAME: SLExtMsgEntityWbkpis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLExtMsgEntityWbkpis")]
	public class SLExtMsgEntityWbkpis : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_UserSelectedKPISp([Optional] string ExtMsgType,
		[Optional, DefaultParameterValue(0)] int? FilterUnselected)
		{
			var iCLM_UserSelectedKPIExt = new CLM_UserSelectedKPIFactory().Create(this, true);
			
			var result = iCLM_UserSelectedKPIExt.CLM_UserSelectedKPISp(ExtMsgType,
			FilterUnselected);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveUserSelectedKPISp(int? Selected,
		int? KPINum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSaveUserSelectedKPIExt = new SaveUserSelectedKPIFactory().Create(appDb);
				
				var result = iSaveUserSelectedKPIExt.SaveUserSelectedKPISp(Selected,
				KPINum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
