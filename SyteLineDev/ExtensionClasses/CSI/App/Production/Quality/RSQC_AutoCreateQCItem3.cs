//PROJECT NAME: Production
//CLASS NAME: RSQC_AutoCreateQCItem3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_AutoCreateQCItem3 : IRSQC_AutoCreateQCItem3
	{
		readonly IApplicationDB appDB;
		
		public RSQC_AutoCreateQCItem3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RSQC_AutoCreateQCItem3Sp(
			string i_po,
			int? i_line,
			string Infobar)
		{
			PoNumType _i_po = i_po;
			PoLineType _i_line = i_line;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_AutoCreateQCItem3Sp";
				
				appDB.AddCommandParameter(cmd, "i_po", _i_po, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_line", _i_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
