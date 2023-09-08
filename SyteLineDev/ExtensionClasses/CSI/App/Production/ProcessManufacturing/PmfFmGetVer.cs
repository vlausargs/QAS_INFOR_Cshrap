//PROJECT NAME: CSIPmf
//CLASS NAME: PmfFmGetVer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmGetVer
	{
		int PmfFmGetVerSp(string fm);
	}
	
	public class PmfFmGetVer : IPmfFmGetVer
	{
		readonly IApplicationDB appDB;
		
		public PmfFmGetVer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PmfFmGetVerSp(string fm)
		{
			ProcessMfgFormulaIdType _fm = fm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmGetVerSp";
				
				appDB.AddCommandParameter(cmd, "fm", _fm, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
