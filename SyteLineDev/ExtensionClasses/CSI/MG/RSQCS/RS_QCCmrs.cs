//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCCmrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCCmrs")]
	public class RS_QCCmrs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetUser2Sp(ref string o_emp_num,
		ref string o_name,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetUser2Ext = new RSQC_GetUser2Factory().Create(appDb);
				
				var result = iRSQC_GetUser2Ext.RSQC_GetUser2Sp(o_emp_num,
				o_name,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_emp_num = result.o_emp_num;
				o_name = result.o_name;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
