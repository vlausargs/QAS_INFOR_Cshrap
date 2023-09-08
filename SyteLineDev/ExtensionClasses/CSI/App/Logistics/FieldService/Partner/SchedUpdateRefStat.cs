//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedUpdateRefStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedUpdateRefStat
	{
		int SchedUpdateRefStatSp(Guid? RowPointer,
		                         string StatCode,
		                         ref string Infobar);
	}
	
	public class SchedUpdateRefStat : ISchedUpdateRefStat
	{
		readonly IApplicationDB appDB;
		
		public SchedUpdateRefStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SchedUpdateRefStatSp(Guid? RowPointer,
		                                string StatCode,
		                                ref string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			FSStatCodeType _StatCode = StatCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedUpdateRefStatSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
