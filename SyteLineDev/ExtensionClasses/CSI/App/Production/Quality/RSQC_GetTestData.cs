//PROJECT NAME: Production
//CLASS NAME: RSQC_GetTestData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetTestData : IRSQC_GetTestData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetTestData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_each,
		string o_batch,
		string o_summary,
		string o_fail,
		string Infobar) RSQC_GetTestDataSp(int? i_rcvr,
		DateTime? i_trans_date,
		string o_each,
		string o_batch,
		string o_summary,
		string o_fail,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			StringType _o_each = o_each;
			StringType _o_batch = o_batch;
			StringType _o_summary = o_summary;
			StringType _o_fail = o_fail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetTestDataSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_each", _o_each, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_batch", _o_batch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_summary", _o_summary, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_fail", _o_fail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_each = _o_each;
				o_batch = _o_batch;
				o_summary = _o_summary;
				o_fail = _o_fail;
				Infobar = _Infobar;
				
				return (Severity, o_each, o_batch, o_summary, o_fail, Infobar);
			}
		}
	}
}
