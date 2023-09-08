//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateBatchTests.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateBatchTests : IRSQC_CreateBatchTests
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateBatchTests(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_message,
		string Infobar) RSQC_CreateBatchTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		string o_message,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			DescriptionType _o_message = o_message;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateBatchTestsSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_message", _o_message, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_message = _o_message;
				Infobar = _Infobar;
				
				return (Severity, o_message, Infobar);
			}
		}
	}
}
