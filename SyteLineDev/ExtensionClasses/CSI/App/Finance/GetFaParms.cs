//PROJECT NAME: CSIFinance
//CLASS NAME: GetFaParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGetFaParms
	{
		int GetFaParmsSp(ref string Code1Title,
		                 ref string Code2Title,
		                 ref string Code3Title,
		                 ref string Code4Title,
		                 ref short? NumPeriods);
	}
	
	public class GetFaParms : IGetFaParms
	{
		readonly IApplicationDB appDB;
		
		public GetFaParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetFaParmsSp(ref string Code1Title,
		                        ref string Code2Title,
		                        ref string Code3Title,
		                        ref string Code4Title,
		                        ref short? NumPeriods)
		{
			DeprCodeType _Code1Title = Code1Title;
			DeprCodeType _Code2Title = Code2Title;
			DeprCodeType _Code3Title = Code3Title;
			DeprCodeType _Code4Title = Code4Title;
			FaPeriodsType _NumPeriods = NumPeriods;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFaParmsSp";
				
				appDB.AddCommandParameter(cmd, "Code1Title", _Code1Title, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Code2Title", _Code2Title, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Code3Title", _Code3Title, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Code4Title", _Code4Title, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumPeriods", _NumPeriods, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Code1Title = _Code1Title;
				Code2Title = _Code2Title;
				Code3Title = _Code3Title;
				Code4Title = _Code4Title;
				NumPeriods = _NumPeriods;
				
				return Severity;
			}
		}
	}
}
