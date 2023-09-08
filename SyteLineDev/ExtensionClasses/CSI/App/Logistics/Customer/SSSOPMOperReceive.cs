//PROJECT NAME: Logistics
//CLASS NAME: SSSOPMOperReceive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSOPMOperReceive : ISSSOPMOperReceive
	{
		readonly IApplicationDB appDB;
		
		public SSSOPMOperReceive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSOPMOperReceiveSp(
			string job,
			int? suffix,
			int? oper_num,
			decimal? qty_moved,
			string Infobar,
			int? ThisSequenceOnly = null)
		{
			JobType _job = job;
			SuffixType _suffix = suffix;
			OperNumType _oper_num = oper_num;
			QtyUnitType _qty_moved = qty_moved;
			InfobarType _Infobar = Infobar;
			JobmatlSequenceType _ThisSequenceOnly = ThisSequenceOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSOPMOperReceiveSp";
				
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oper_num", _oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_moved", _qty_moved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThisSequenceOnly", _ThisSequenceOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
