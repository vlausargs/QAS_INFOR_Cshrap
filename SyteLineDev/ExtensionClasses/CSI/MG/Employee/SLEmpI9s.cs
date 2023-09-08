//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpI9s.cs

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
    [IDOExtensionClass("SLEmpI9s")]
    public class SLEmpI9s : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PredisplayEmploymentEligibilitySp(ref int? PCheckSsnEnabled)
		{
			var iPredisplayEmploymentEligibilityExt = new PredisplayEmploymentEligibilityFactory().Create(this, true);
			
			var result = iPredisplayEmploymentEligibilityExt.PredisplayEmploymentEligibilitySp(PCheckSsnEnabled);
			
			PCheckSsnEnabled = result.PCheckSsnEnabled;
			
			return result.ReturnCode??0;
		}

    }
}
