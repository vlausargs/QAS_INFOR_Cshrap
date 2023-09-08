//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateFailTests.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateFailTests : IRSQC_CreateFailTests
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateFailTests(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CreateFailTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		decimal? i_num_entries,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			QtyUnitType _i_num_entries = i_num_entries;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateFailTestsSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_num_entries", _i_num_entries, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
