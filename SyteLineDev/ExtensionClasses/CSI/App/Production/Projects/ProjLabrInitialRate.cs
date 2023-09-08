//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrInitialRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjLabrInitialRate
	{
		int ProjLabrInitialRateSp(string EmpNum,
		                          string PayType,
		                          string Shift,
		                          DateTime? TransDate,
		                          ref decimal? PrRate,
		                          ref decimal? ProjRate,
		                          ref string Infobar);
	}
	
	public class ProjLabrInitialRate : IProjLabrInitialRate
	{
		readonly IApplicationDB appDB;
		
		public ProjLabrInitialRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjLabrInitialRateSp(string EmpNum,
		                                 string PayType,
		                                 string Shift,
		                                 DateTime? TransDate,
		                                 ref decimal? PrRate,
		                                 ref decimal? ProjRate,
		                                 ref string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			PayBasisType _PayType = PayType;
			ShiftType _Shift = Shift;
			CurrentDateType _TransDate = TransDate;
			PayRateType _PrRate = PrRate;
			PayRateType _ProjRate = ProjRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjLabrInitialRateSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrRate", _PrRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProjRate", _ProjRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrRate = _PrRate;
				ProjRate = _ProjRate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
