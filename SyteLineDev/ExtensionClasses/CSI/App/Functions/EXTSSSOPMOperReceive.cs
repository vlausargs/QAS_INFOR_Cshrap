//PROJECT NAME: Data
//CLASS NAME: EXTSSSOPMOperReceive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSOPMOperReceive : IEXTSSSOPMOperReceive
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSOPMOperReceive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSOPMOperReceiveSp(
			string job,
			int? suffix,
			int? oper_num,
			decimal? qty_moved,
			string Infobar)
		{
			JobType _job = job;
			SuffixType _suffix = suffix;
			OperNumType _oper_num = oper_num;
			QtyUnitType _qty_moved = qty_moved;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSOPMOperReceiveSp";
				
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oper_num", _oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_moved", _qty_moved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
