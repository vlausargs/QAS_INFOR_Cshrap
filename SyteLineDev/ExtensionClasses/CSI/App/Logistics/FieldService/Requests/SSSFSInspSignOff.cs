//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSInspSignOff.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSInspSignOff
	{
		int SSSFSInspSignOffSp(string Type,
		                       Guid? RowPointer,
		                       ref string Infobar);
	}
	
	public class SSSFSInspSignOff : ISSSFSInspSignOff
	{
		readonly IApplicationDB appDB;
		
		public SSSFSInspSignOff(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSInspSignOffSp(string Type,
		                              Guid? RowPointer,
		                              ref string Infobar)
		{
			StringType _Type = Type;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSInspSignOffSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
