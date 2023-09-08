//PROJECT NAME: CSIProduct
//CLASS NAME: JobOrderStdFormPredisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobOrderStdFormPredisplay
	{
		int JobOrderStdFormPredisplaySp(ref string ApsParmValue,
		                                ref byte? CalcBOMSubJobDates,
		                                ref short? ApsCalcSubJobDates,
		                                ref string InvParmValue);
	}
	
	public class JobOrderStdFormPredisplay : IJobOrderStdFormPredisplay
	{
		readonly IApplicationDB appDB;
		
		public JobOrderStdFormPredisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int JobOrderStdFormPredisplaySp(ref string ApsParmValue,
		                                       ref byte? CalcBOMSubJobDates,
		                                       ref short? ApsCalcSubJobDates,
		                                       ref string InvParmValue)
		{
			ApsModeType _ApsParmValue = ApsParmValue;
			ListYesNoType _CalcBOMSubJobDates = CalcBOMSubJobDates;
			SmallintType _ApsCalcSubJobDates = ApsCalcSubJobDates;
			WhseType _InvParmValue = InvParmValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOrderStdFormPredisplaySp";
				
				appDB.AddCommandParameter(cmd, "ApsParmValue", _ApsParmValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalcBOMSubJobDates", _CalcBOMSubJobDates, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApsCalcSubJobDates", _ApsCalcSubJobDates, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvParmValue", _InvParmValue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ApsParmValue = _ApsParmValue;
				CalcBOMSubJobDates = _CalcBOMSubJobDates;
				ApsCalcSubJobDates = _ApsCalcSubJobDates;
				InvParmValue = _InvParmValue;
				
				return Severity;
			}
		}
	}
}
