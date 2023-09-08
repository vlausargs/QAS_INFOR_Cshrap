//PROJECT NAME: Production
//CLASS NAME: RSQC_SetTestValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetTestValues : IRSQC_SetTestValues
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetTestValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_seq,
		string Infobar) RSQC_SetTestValuesSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? i_testseq,
		int? o_seq,
		string Infobar)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_entity = i_entity;
			QCTestSeqType _i_testseq = i_testseq;
			QCIntegerType _o_seq = o_seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetTestValuesSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_testseq", _i_testseq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_seq", _o_seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_seq = _o_seq;
				Infobar = _Infobar;
				
				return (Severity, o_seq, Infobar);
			}
		}
	}
}
