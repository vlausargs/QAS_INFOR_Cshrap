//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefOrigPO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefOrigPO : IRSQC_XRefOrigPO
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_XRefOrigPO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar) RSQC_XRefOrigPOSp(int? i_rcvr,
		string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			PoNumType _o_ref_num = o_ref_num;
			PoLineType _o_ref_line = o_ref_line;
			PoReleaseType _o_ref_rel = o_ref_rel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_XRefOrigPOSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_ref_num", _o_ref_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_line", _o_ref_line, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_rel", _o_ref_rel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_ref_num = _o_ref_num;
				o_ref_line = _o_ref_line;
				o_ref_rel = _o_ref_rel;
				Infobar = _Infobar;
				
				return (Severity, o_ref_num, o_ref_line, o_ref_rel, Infobar);
			}
		}
	}
}
