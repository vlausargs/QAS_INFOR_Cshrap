//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdateApptStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedUpdateApptStat
	{
		(int? ReturnCode, string Infobar) SchedUpdateApptStatSp(Guid? RowPointer,
		string StatCode,
		string Infobar,
		Guid? ParentRowPointer = null);
	}
	
	public class SchedUpdateApptStat : ISchedUpdateApptStat
	{
		readonly IApplicationDB appDB;
		
		public SchedUpdateApptStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SchedUpdateApptStatSp(Guid? RowPointer,
		string StatCode,
		string Infobar,
		Guid? ParentRowPointer = null)
		{
			RowPointerType _RowPointer = RowPointer;
			FSApptStatType _StatCode = StatCode;
			InfobarType _Infobar = Infobar;
			RowPointerType _ParentRowPointer = ParentRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedUpdateApptStatSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParentRowPointer", _ParentRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
