//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTestXRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTestXRef : IRSQC_CreateTestXRef
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateTestXRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CreateTestXRefSp(int? i_rcvr,
		DateTime? i_trans_date,
		int? i_sequence,
		string i_doc_num,
		string i_type,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			DateType _i_trans_date = i_trans_date;
			QCIntegerType _i_sequence = i_sequence;
			QCDocNumType _i_doc_num = i_doc_num;
			StringType _i_type = i_type;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateTestXRefSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trans_date", _i_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_sequence", _i_sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_doc_num", _i_doc_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_type", _i_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
