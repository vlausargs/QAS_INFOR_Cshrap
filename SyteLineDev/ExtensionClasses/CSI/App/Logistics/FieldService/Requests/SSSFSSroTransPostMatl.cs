//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransPostMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroTransPostMatl
	{
		int SSSFSSroTransPostMatlSp(Guid? iRowPointer,
		                            byte? iLineTrans,
		                            string iMode,
		                            ref string Infobar);
	}
	
	public class SSSFSSroTransPostMatl : ISSSFSSroTransPostMatl
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransPostMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSroTransPostMatlSp(Guid? iRowPointer,
		                                   byte? iLineTrans,
		                                   string iMode,
		                                   ref string Infobar)
		{
			RowPointerType _iRowPointer = iRowPointer;
			ListYesNoType _iLineTrans = iLineTrans;
			UnusedCharType _iMode = iMode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransPostMatlSp";
				
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLineTrans", _iLineTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
