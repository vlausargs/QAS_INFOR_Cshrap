//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetIGFCurrencyCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetIGFCurrencyCodes : IExtFinGetIGFCurrencyCodes
	{
		readonly IApplicationDB appDB;
		
		public ExtFinGetIGFCurrencyCodes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinGetIGFCurrencyCodesSp(
			string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetIGFCurrencyCodesSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
