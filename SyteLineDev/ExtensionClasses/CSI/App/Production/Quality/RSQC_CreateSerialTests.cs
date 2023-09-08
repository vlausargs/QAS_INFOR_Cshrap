//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateSerialTests.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateSerialTests : IRSQC_CreateSerialTests
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateSerialTests(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CreateSerialTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		string i_ref_type,
		string i_item,
		int? i_oper_num,
		string i_entity,
		string i_ref_num,
		int? i_ref_line,
		int? i_ref_release,
		string i_test_type,
		int? i_test_seq,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			QCRefType _i_ref_type = i_ref_type;
			ItemType _i_item = i_item;
			OperNumPoReleaseType _i_oper_num = i_oper_num;
			QCDocNumType _i_entity = i_entity;
			QCRefNumType _i_ref_num = i_ref_num;
			QCRefLineType _i_ref_line = i_ref_line;
			QCRefReleaseType _i_ref_release = i_ref_release;
			QCCharType _i_test_type = i_test_type;
			QCTestSeqType _i_test_seq = i_test_seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateSerialTestsSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_oper_num", _i_oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_num", _i_ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_line", _i_ref_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_release", _i_ref_release, ParameterDirection.Input);
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
