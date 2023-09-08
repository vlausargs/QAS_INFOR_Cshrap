//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransPostLabor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroTransPostLabor
	{
		int SSSFSSroTransPostLaborSp(Guid? iRowPointer,
		                             string iMode,
		                             ref string Infobar);
	}
	
	public class SSSFSSroTransPostLabor : ISSSFSSroTransPostLabor
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransPostLabor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSroTransPostLaborSp(Guid? iRowPointer,
		                                    string iMode,
		                                    ref string Infobar)
		{
			RowPointerType _iRowPointer = iRowPointer;
			StringType _iMode = iMode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransPostLaborSp";
				
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
