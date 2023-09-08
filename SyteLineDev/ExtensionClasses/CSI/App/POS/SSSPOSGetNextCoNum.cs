//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetNextCoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetNextCoNum : ISSSPOSGetNextCoNum
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetNextCoNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NextCoNum,
			string Infobar) SSSPOSGetNextCoNumSp(
			string NextCoNum,
			string Infobar)
		{
			CoNumType _NextCoNum = NextCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSGetNextCoNumSp";
				
				appDB.AddCommandParameter(cmd, "NextCoNum", _NextCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextCoNum = _NextCoNum;
				Infobar = _Infobar;
				
				return (Severity, NextCoNum, Infobar);
			}
		}
	}
}
