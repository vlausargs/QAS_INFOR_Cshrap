//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpSelfServPreqs.cs

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
	[IDOExtensionClass("SLEmpSelfServPreqs")]
	public class SLEmpSelfServPreqs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ESSGetSupUsernameSp([Optional] string EmpNum,
		                               ref string SupUsername)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iESSGetSupUsernameExt = new ESSGetSupUsernameFactory().Create(appDb);
				
				var result = iESSGetSupUsernameExt.ESSGetSupUsernameSp(EmpNum,
				                                                       SupUsername);
				
				int Severity = result.ReturnCode.Value;
				SupUsername = result.SupUsername;
				return Severity;
			}
		}
	}
}
