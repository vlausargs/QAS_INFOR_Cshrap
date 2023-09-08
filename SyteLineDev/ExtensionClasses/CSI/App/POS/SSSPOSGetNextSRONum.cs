//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetNextSRONum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetNextSRONum : ISSSPOSGetNextSRONum
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetNextSRONum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NextSRONum,
			string Infobar) SSSPOSGetNextSRONumSp(
			string NextSRONum,
			string Infobar)
		{
			FSSRONumType _NextSRONum = NextSRONum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSGetNextSRONumSp";
				
				appDB.AddCommandParameter(cmd, "NextSRONum", _NextSRONum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextSRONum = _NextSRONum;
				Infobar = _Infobar;
				
				return (Severity, NextSRONum, Infobar);
			}
		}
	}
}
