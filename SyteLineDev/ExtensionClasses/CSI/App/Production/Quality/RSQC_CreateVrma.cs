//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateVrma.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateVrma : IRSQC_CreateVrma
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateVrma(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_vrma,
		string Infobar) RSQC_CreateVrmaSp(string i_mrr,
		decimal? i_qty,
		string i_vend,
		string i_reason,
		int? o_vrma,
		string Infobar)
		{
			QCDocNumType _i_mrr = i_mrr;
			QtyUnitType _i_qty = i_qty;
			QCDocNumType _i_vend = i_vend;
			QCCodeType _i_reason = i_reason;
			QCRcvrNumType _o_vrma = o_vrma;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateVrmaSp";
				
				appDB.AddCommandParameter(cmd, "i_mrr", _i_mrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qty", _i_qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vend", _i_vend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_reason", _i_reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_vrma", _o_vrma, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_vrma = _o_vrma;
				Infobar = _Infobar;
				
				return (Severity, o_vrma, Infobar);
			}
		}
	}
}
