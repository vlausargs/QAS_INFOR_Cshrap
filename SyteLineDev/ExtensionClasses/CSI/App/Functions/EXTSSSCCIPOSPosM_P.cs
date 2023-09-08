//PROJECT NAME: Data
//CLASS NAME: EXTSSSCCIPOSPosM_P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSCCIPOSPosM_P : IEXTSSSCCIPOSPosM_P
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSCCIPOSPosM_P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSCCIPOSPosM_PSp(
			string POSNum,
			string InvNum,
			string Infobar)
		{
			StringType _POSNum = POSNum;
			InvNumType _InvNum = InvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSCCIPOSPosM_PSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
