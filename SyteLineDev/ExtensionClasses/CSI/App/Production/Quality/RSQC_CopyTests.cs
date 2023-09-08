//PROJECT NAME: Production
//CLASS NAME: RSQC_CopyTests.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CopyTests : IRSQC_CopyTests
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CopyTests(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CopyTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type = null,
		int? i_test_seq = null,
		string i_item2 = null,
		string i_ref_type2 = null,
		string i_entity2 = null,
		string i_test_type2 = null,
		int? i_test_seq2 = null,
		string i_item3 = null,
		string i_ref_type3 = null,
		string i_entity3 = null,
		string i_test_type3 = null,
		int? i_test_seq3 = null,
		string Infobar = null)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_entity = i_entity;
			QCCharType _i_test_type = i_test_type;
			QCTestSeqType _i_test_seq = i_test_seq;
			ItemType _i_item2 = i_item2;
			QCRefType _i_ref_type2 = i_ref_type2;
			QCDocNumType _i_entity2 = i_entity2;
			QCCharType _i_test_type2 = i_test_type2;
			QCTestSeqType _i_test_seq2 = i_test_seq2;
			ItemType _i_item3 = i_item3;
			QCRefType _i_ref_type3 = i_ref_type3;
			QCDocNumType _i_entity3 = i_entity3;
			QCCharType _i_test_type3 = i_test_type3;
			QCTestSeqType _i_test_seq3 = i_test_seq3;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CopyTestsSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_type", _i_test_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_seq", _i_test_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_item2", _i_item2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type2", _i_ref_type2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity2", _i_entity2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_type2", _i_test_type2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_seq2", _i_test_seq2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_item3", _i_item3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type3", _i_ref_type3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity3", _i_entity3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_type3", _i_test_type3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_seq3", _i_test_seq3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
