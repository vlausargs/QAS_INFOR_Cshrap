//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSUnitConfigDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigDel
	{
		int SSSFSUnitConfigDelSp(int? iCompID,
		                         ref string Infobar);
	}
	
	public class SSSFSUnitConfigDel : ISSSFSUnitConfigDel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConfigDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSUnitConfigDelSp(int? iCompID,
		                                ref string Infobar)
		{
			FSCompIdType _iCompID = iCompID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigDelSp";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
