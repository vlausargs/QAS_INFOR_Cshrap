//PROJECT NAME: CSIEmployee
//CLASS NAME: GetEmpTotalHrsAndPay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGetEmpTotalHrsAndPay
	{
		int GetEmpTotalHrsAndPaySp(DateTime? StartingCheckDate,
		                           DateTime? EndingCheckDate,
		                           ref decimal? TotRegHrs,
		                           ref decimal? TotRegPay,
		                           ref decimal? TotOTHrs,
		                           ref decimal? TotOTPay,
		                           ref decimal? TotDTHrs,
		                           ref decimal? TotDTPay,
		                           ref decimal? TotHolHrs,
		                           ref decimal? TotHolPay,
		                           ref decimal? TotSickHrs,
		                           ref decimal? TotSickPay,
		                           ref decimal? TotVacHrs,
		                           ref decimal? TotVacPay,
		                           ref decimal? TotOthHrs,
		                           ref decimal? TotOthPay,
		                           ref decimal? TotHrs,
		                           ref decimal? TotPay,
		                           ref string Infobar);
	}
	
	public class GetEmpTotalHrsAndPay : IGetEmpTotalHrsAndPay
	{
		readonly IApplicationDB appDB;
		
		public GetEmpTotalHrsAndPay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetEmpTotalHrsAndPaySp(DateTime? StartingCheckDate,
		                                  DateTime? EndingCheckDate,
		                                  ref decimal? TotRegHrs,
		                                  ref decimal? TotRegPay,
		                                  ref decimal? TotOTHrs,
		                                  ref decimal? TotOTPay,
		                                  ref decimal? TotDTHrs,
		                                  ref decimal? TotDTPay,
		                                  ref decimal? TotHolHrs,
		                                  ref decimal? TotHolPay,
		                                  ref decimal? TotSickHrs,
		                                  ref decimal? TotSickPay,
		                                  ref decimal? TotVacHrs,
		                                  ref decimal? TotVacPay,
		                                  ref decimal? TotOthHrs,
		                                  ref decimal? TotOthPay,
		                                  ref decimal? TotHrs,
		                                  ref decimal? TotPay,
		                                  ref string Infobar)
		{
			DateType _StartingCheckDate = StartingCheckDate;
			DateType _EndingCheckDate = EndingCheckDate;
			TotalHoursType _TotRegHrs = TotRegHrs;
			PrYtdAmountType _TotRegPay = TotRegPay;
			TotalHoursType _TotOTHrs = TotOTHrs;
			PrYtdAmountType _TotOTPay = TotOTPay;
			TotalHoursType _TotDTHrs = TotDTHrs;
			PrYtdAmountType _TotDTPay = TotDTPay;
			TotalHoursType _TotHolHrs = TotHolHrs;
			PrYtdAmountType _TotHolPay = TotHolPay;
			TotalHoursType _TotSickHrs = TotSickHrs;
			PrYtdAmountType _TotSickPay = TotSickPay;
			TotalHoursType _TotVacHrs = TotVacHrs;
			PrYtdAmountType _TotVacPay = TotVacPay;
			TotalHoursType _TotOthHrs = TotOthHrs;
			PrYtdAmountType _TotOthPay = TotOthPay;
			TotalHoursType _TotHrs = TotHrs;
			PrYtdAmountType _TotPay = TotPay;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEmpTotalHrsAndPaySp";
				
				appDB.AddCommandParameter(cmd, "StartingCheckDate", _StartingCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCheckDate", _EndingCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotRegHrs", _TotRegHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotRegPay", _TotRegPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotOTHrs", _TotOTHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotOTPay", _TotOTPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotDTHrs", _TotDTHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotDTPay", _TotDTPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotHolHrs", _TotHolHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotHolPay", _TotHolPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotSickHrs", _TotSickHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotSickPay", _TotSickPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotVacHrs", _TotVacHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotVacPay", _TotVacPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotOthHrs", _TotOthHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotOthPay", _TotOthPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotHrs", _TotHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotPay", _TotPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotRegHrs = _TotRegHrs;
				TotRegPay = _TotRegPay;
				TotOTHrs = _TotOTHrs;
				TotOTPay = _TotOTPay;
				TotDTHrs = _TotDTHrs;
				TotDTPay = _TotDTPay;
				TotHolHrs = _TotHolHrs;
				TotHolPay = _TotHolPay;
				TotSickHrs = _TotSickHrs;
				TotSickPay = _TotSickPay;
				TotVacHrs = _TotVacHrs;
				TotVacPay = _TotVacPay;
				TotOthHrs = _TotOthHrs;
				TotOthPay = _TotOthPay;
				TotHrs = _TotHrs;
				TotPay = _TotPay;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
