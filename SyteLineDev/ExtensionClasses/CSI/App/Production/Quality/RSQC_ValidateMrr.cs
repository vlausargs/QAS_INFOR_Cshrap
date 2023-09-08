//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateMrr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateMrr : IRSQC_ValidateMrr
	{
		readonly IApplicationDB appDB;
		
		public RSQC_ValidateMrr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RSQC_ValidateMrrSp(
			int? RcvrNum,
			string Infobar)
		{
			IntType _RcvrNum = RcvrNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateMrr";
				
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
