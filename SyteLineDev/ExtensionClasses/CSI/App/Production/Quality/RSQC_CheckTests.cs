//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckTests.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckTests : IRSQC_CheckTests
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckTests(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CheckTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type,
		int? i_test_seq,
		string Infobar)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_entity = i_entity;
			QCCharType _i_test_type = i_test_type;
			QCTestSeqType _i_test_seq = i_test_seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckTestsSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_type", _i_test_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_seq", _i_test_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
