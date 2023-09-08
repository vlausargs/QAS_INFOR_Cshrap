//PROJECT NAME: Production
//CLASS NAME: RSQC_SetItemTestSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetItemTestSeq : IRSQC_SetItemTestSeq
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetItemTestSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_testseq,
		string Infobar) RSQC_SetItemTestSeqSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? o_testseq,
		string Infobar)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_entity = i_entity;
			QCTestSeqType _o_testseq = o_testseq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetItemTestSeqSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_testseq", _o_testseq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_testseq = _o_testseq;
				Infobar = _Infobar;
				
				return (Severity, o_testseq, Infobar);
			}
		}
	}
}
