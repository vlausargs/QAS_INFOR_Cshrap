//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTrr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTrr : IRSQC_CreateTrr
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateTrr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_trr,
		string Infobar) RSQC_CreateTrrSp(int? i_trcvr,
		string o_trr,
		string Infobar)
		{
			QCRcvrNumType _i_trcvr = i_trcvr;
			QCDocNumType _o_trr = o_trr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateTrrSp";
				
				appDB.AddCommandParameter(cmd, "i_trcvr", _i_trcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_trr", _o_trr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_trr = _o_trr;
				Infobar = _Infobar;
				
				return (Severity, o_trr, Infobar);
			}
		}
	}
}
