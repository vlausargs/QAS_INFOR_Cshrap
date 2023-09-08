//PROJECT NAME: Production
//CLASS NAME: RSQC_AutoCreateQCItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_AutoCreateQCItem : IRSQC_AutoCreateQCItem
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_AutoCreateQCItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_messages,
		string Infobar) RSQC_AutoCreateQCItemSp(string i_item,
		string i_ref_type,
		string i_vend_num,
		string i_job,
		int? i_suffix,
		int? i_oper_num,
		string o_messages,
		string Infobar)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			VendNumType _i_vend_num = i_vend_num;
			JobType _i_job = i_job;
			SuffixType _i_suffix = i_suffix;
			OperNumType _i_oper_num = i_oper_num;
			InfobarType _o_messages = o_messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_AutoCreateQCItemSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vend_num", _i_vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_job", _i_job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_suffix", _i_suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_oper_num", _i_oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_messages", _o_messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_messages = _o_messages;
				Infobar = _Infobar;
				
				return (Severity, o_messages, Infobar);
			}
		}
	}
}
