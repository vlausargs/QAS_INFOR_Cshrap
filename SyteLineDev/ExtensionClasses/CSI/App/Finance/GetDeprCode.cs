//PROJECT NAME: CSIFinance
//CLASS NAME: GetDeprCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGetDeprCode
	{
		int GetDeprCodeSP(ref string DeprCode);
	}
	
	public class GetDeprCode : IGetDeprCode
	{
		readonly IApplicationDB appDB;
		
		public GetDeprCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetDeprCodeSP(ref string DeprCode)
		{
			DeprCodeType _DeprCode = DeprCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDeprCodeSP";
				
				appDB.AddCommandParameter(cmd, "DeprCode", _DeprCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DeprCode = _DeprCode;
				
				return Severity;
			}
		}
	}
}
