//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateQuickMrr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateQuickMrr : IRSQC_CreateQuickMrr
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateQuickMrr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_Messages,
		int? o_rcvr,
		string o_mrr,
		string Infobar) RSQC_CreateQuickMrrSp(int? i_rcvr,
		string i_problem,
		int? i_UseHoldLoc,
		string i_MRRLoc,
		string o_Messages,
		int? o_rcvr,
		string o_mrr,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			StringType _i_problem = i_problem;
			IntType _i_UseHoldLoc = i_UseHoldLoc;
			LocType _i_MRRLoc = i_MRRLoc;
			InfobarType _o_Messages = o_Messages;
			QCRcvrNumType _o_rcvr = o_rcvr;
			QCDocNumType _o_mrr = o_mrr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateQuickMrrSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_problem", _i_problem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_UseHoldLoc", _i_UseHoldLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_MRRLoc", _i_MRRLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_Messages", _o_Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_rcvr", _o_rcvr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_mrr", _o_mrr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_Messages = _o_Messages;
				o_rcvr = _o_rcvr;
				o_mrr = _o_mrr;
				Infobar = _Infobar;
				
				return (Severity, o_Messages, o_rcvr, o_mrr, Infobar);
			}
		}
	}
}
