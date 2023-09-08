//PROJECT NAME: EmployeeExt
//CLASS NAME: SLSicklves.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLSicklves")]
    public class SLSicklves : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrSickSp([Optional] string StartingEmpNum,
		                    [Optional] string EndingEmpNum,
		                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHrSickExt = new HrSickFactory().Create(appDb);
				
				var result = iHrSickExt.HrSickSp(StartingEmpNum,
				                                 EndingEmpNum,
				                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
