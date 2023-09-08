//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateUpdateTestSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateUpdateTestSummary : IRSQC_CreateUpdateTestSummary
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateUpdateTestSummary(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CreateUpdateTestSummarySp(int? i_rcvr,
		DateTime? i_trans_date,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateUpdateTestSummarySp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
