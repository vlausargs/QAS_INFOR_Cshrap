//PROJECT NAME: Logistics
//CLASS NAME: PoLineRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoLineRelease : IPoLineRelease
	{
		readonly IApplicationDB appDB;
		
		
		public PoLineRelease(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PoLine,
		int? PoRelease,
		string Infobar) PoLineReleaseSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoLineReleaseSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoLine = _PoLine;
				PoRelease = _PoRelease;
				Infobar = _Infobar;
				
				return (Severity, PoLine, PoRelease, Infobar);
			}
		}
	}
}
