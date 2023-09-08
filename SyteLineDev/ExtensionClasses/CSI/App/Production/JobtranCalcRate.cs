//PROJECT NAME: Production
//CLASS NAME: JobtranCalcRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtranCalcRate : IJobtranCalcRate
	{
		readonly IApplicationDB appDB;
		
		
		public JobtranCalcRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OutPrRate,
		decimal? OutJobRate) JobtranCalcRateSp(string InPayRate,
		string InEmpNum,
		string InShift,
		DateTime? InTransDate,
		decimal? OutPrRate,
		decimal? OutJobRate)
		{
			PayBasisType _InPayRate = InPayRate;
			EmpNumType _InEmpNum = InEmpNum;
			ShiftType _InShift = InShift;
			DateType _InTransDate = InTransDate;
			PayRateType _OutPrRate = OutPrRate;
			PayRateType _OutJobRate = OutJobRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranCalcRateSp";
				
				appDB.AddCommandParameter(cmd, "InPayRate", _InPayRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InEmpNum", _InEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InShift", _InShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InTransDate", _InTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutPrRate", _OutPrRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutJobRate", _OutJobRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutPrRate = _OutPrRate;
				OutJobRate = _OutJobRate;
				
				return (Severity, OutPrRate, OutJobRate);
			}
		}
	}
}
