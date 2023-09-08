//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckSerialTracked.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckSerialTracked : IRSQC_CheckSerialTracked
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckSerialTracked(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_serial_tracked,
		string Infobar) RSQC_CheckSerialTrackedSp(string i_item,
		string i_ref_type,
		string i_vend_num,
		string i_job,
		int? i_suffix,
		int? i_oper_num,
		int? o_serial_tracked,
		string Infobar)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			VendNumType _i_vend_num = i_vend_num;
			JobType _i_job = i_job;
			SuffixType _i_suffix = i_suffix;
			OperNumType _i_oper_num = i_oper_num;
			IntType _o_serial_tracked = o_serial_tracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckSerialTrackedSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vend_num", _i_vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_job", _i_job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_suffix", _i_suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_oper_num", _i_oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_serial_tracked", _o_serial_tracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_serial_tracked = _o_serial_tracked;
				Infobar = _Infobar;
				
				return (Severity, o_serial_tracked, Infobar);
			}
		}
	}
}
