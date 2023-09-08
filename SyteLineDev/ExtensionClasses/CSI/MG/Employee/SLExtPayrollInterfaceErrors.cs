//PROJECT NAME: EmployeeExt
//CLASS NAME: SLExtPayrollInterfaceErrors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLExtPayrollInterfaceErrors")]
    public class SLExtPayrollInterfaceErrors : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExtPrIfErrorSaveSp(DateTime? ErrDate,
			string ErrMsg,
			ref string Infobar)
		{
			var iExtPrIfErrorSaveExt = this.GetService<IExtPrIfErrorSave>();

			var result = iExtPrIfErrorSaveExt.ExtPrIfErrorSaveSp(ErrDate,
				ErrMsg,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

    }
}
