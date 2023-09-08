//PROJECT NAME: Data
//CLASS NAME: CustRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CustRev : ICustRev
	{
		readonly IApplicationDB appDB;
		
		public CustRev(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ActRev) CustRevSp(
			string ProjNum,
			string MsNum,
			int? CalcAct,
			decimal? ActRev)
		{
			ProjNumType _ProjNum = ProjNum;
			ProjMsNumType _MsNum = MsNum;
			FlagNyType _CalcAct = CalcAct;
			AmountType _ActRev = ActRev;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustRevSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsNum", _MsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcAct", _CalcAct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActRev", _ActRev, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ActRev = _ActRev;
				
				return (Severity, ActRev);
			}
		}
	}
}
