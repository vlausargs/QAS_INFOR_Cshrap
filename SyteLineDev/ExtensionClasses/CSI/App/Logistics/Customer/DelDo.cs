//PROJECT NAME: CSICustomer
//CLASS NAME: DelDo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDelDo
	{
		(int? ReturnCode, string Infobar) DelDoSp(string stat,
		string do_num_start,
		string do_num_end,
		string cust_num_start,
		string cust_num_end,
		int? cust_seq_start,
		int? cust_seq_end,
		DateTime? pu_date_start,
		DateTime? pu_date_end,
		int? pu_date_null,
		string Infobar,
		short? StartingPUDateOffset = null,
		short? EndingPUDateOffset = null);
	}
	
	public class DelDo : IDelDo
	{
		readonly IApplicationDB appDB;
		
		public DelDo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DelDoSp(string stat,
		string do_num_start,
		string do_num_end,
		string cust_num_start,
		string cust_num_end,
		int? cust_seq_start,
		int? cust_seq_end,
		DateTime? pu_date_start,
		DateTime? pu_date_end,
		int? pu_date_null,
		string Infobar,
		short? StartingPUDateOffset = null,
		short? EndingPUDateOffset = null)
		{
			DoStatusType _stat = stat;
			DoNumType _do_num_start = do_num_start;
			DoNumType _do_num_end = do_num_end;
			CustNumType _cust_num_start = cust_num_start;
			CustNumType _cust_num_end = cust_num_end;
			CustSeqType _cust_seq_start = cust_seq_start;
			CustSeqType _cust_seq_end = cust_seq_end;
			DateType _pu_date_start = pu_date_start;
			DateType _pu_date_end = pu_date_end;
			IntType _pu_date_null = pu_date_null;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingPUDateOffset = StartingPUDateOffset;
			DateOffsetType _EndingPUDateOffset = EndingPUDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelDoSp";
				
				appDB.AddCommandParameter(cmd, "stat", _stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "do_num_start", _do_num_start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "do_num_end", _do_num_end, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_num_start", _cust_num_start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_num_end", _cust_num_end, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_seq_start", _cust_seq_start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_seq_end", _cust_seq_end, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pu_date_start", _pu_date_start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pu_date_end", _pu_date_end, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pu_date_null", _pu_date_null, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingPUDateOffset", _StartingPUDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPUDateOffset", _EndingPUDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
