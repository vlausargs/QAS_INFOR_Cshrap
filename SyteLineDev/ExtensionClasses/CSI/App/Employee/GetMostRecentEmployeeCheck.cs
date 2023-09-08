//PROJECT NAME: CSIEmployee
//CLASS NAME: GetMostRecentEmployeeCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGetMostRecentEmployeeCheck
	{
		int GetMostRecentEmployeeCheckSp(string EmpNum,
		                                 ref DateTime? CheckDate,
		                                 short? Seq,
		                                 ref int? CheckNum,
		                                 ref Guid? RowPointer,
		                                 ref DateTime? PerStart,
		                                 ref DateTime? PerEnd,
		                                 ref decimal? GrossPay,
		                                 ref decimal? NetPay,
		                                 ref decimal? TotalTaxes,
		                                 ref decimal? TotalDed,
		                                 ref decimal? DirectDep,
		                                 ref string Infobar);
	}
	
	public class GetMostRecentEmployeeCheck : IGetMostRecentEmployeeCheck
	{
		readonly IApplicationDB appDB;
		
		public GetMostRecentEmployeeCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMostRecentEmployeeCheckSp(string EmpNum,
		                                        ref DateTime? CheckDate,
		                                        short? Seq,
		                                        ref int? CheckNum,
		                                        ref Guid? RowPointer,
		                                        ref DateTime? PerStart,
		                                        ref DateTime? PerEnd,
		                                        ref decimal? GrossPay,
		                                        ref decimal? NetPay,
		                                        ref decimal? TotalTaxes,
		                                        ref decimal? TotalDed,
		                                        ref decimal? DirectDep,
		                                        ref string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			DateType _CheckDate = CheckDate;
			PrtrxSeqType _Seq = Seq;
			PrCheckNumType _CheckNum = CheckNum;
			RowPointerType _RowPointer = RowPointer;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			PrAmountType _GrossPay = GrossPay;
			PrAmountType _NetPay = NetPay;
			PrAmountType _TotalTaxes = TotalTaxes;
			PrAmountType _TotalDed = TotalDed;
			PrAmountType _DirectDep = DirectDep;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMostRecentEmployeeCheckSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GrossPay", _GrossPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NetPay", _NetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalTaxes", _TotalTaxes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalDed", _TotalDed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DirectDep", _DirectDep, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CheckDate = _CheckDate;
				CheckNum = _CheckNum;
				RowPointer = _RowPointer;
				PerStart = _PerStart;
				PerEnd = _PerEnd;
				GrossPay = _GrossPay;
				NetPay = _NetPay;
				TotalTaxes = _TotalTaxes;
				TotalDed = _TotalDed;
				DirectDep = _DirectDep;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
