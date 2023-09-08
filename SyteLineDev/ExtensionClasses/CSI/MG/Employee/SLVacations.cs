//PROJECT NAME: EmployeeExt
//CLASS NAME: SLVacations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLVacations")]
    public class SLVacations : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SVacSetDefaultSp(string pEmpNum,
		                            [Optional, DefaultParameterValue("F")] string DateMethod,
		[Optional] DateTime? FixedDate,
		ref byte? VacationActive,
		ref decimal? VacationDaysEarned,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSVacSetDefaultExt = new SVacSetDefaultFactory().Create(appDb);
				
				var result = iSVacSetDefaultExt.SVacSetDefaultSp(pEmpNum,
				                                                 DateMethod,
				                                                 FixedDate,
				                                                 VacationActive,
				                                                 VacationDaysEarned,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				VacationActive = result.VacationActive;
				VacationDaysEarned = result.VacationDaysEarned;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SVacSp(string pEmpNum,
		decimal? VacationDaysReimbursed,
		decimal? VacationDaysLytd,
		decimal? VacationDaysUsed,
		ref int? VacationActive,
		ref decimal? VacationDaysEarned,
		ref DateTime? VacationLastUpdate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSVacExt = new SVacFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSVacExt.SVacSp(pEmpNum,
				VacationDaysReimbursed,
				VacationDaysLytd,
				VacationDaysUsed,
				VacationActive,
				VacationDaysEarned,
				VacationLastUpdate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				VacationActive = result.VacationActive;
				VacationDaysEarned = result.VacationDaysEarned;
				VacationLastUpdate = result.VacationLastUpdate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
