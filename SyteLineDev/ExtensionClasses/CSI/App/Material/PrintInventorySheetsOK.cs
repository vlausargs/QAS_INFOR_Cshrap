//PROJECT NAME: Material
//CLASS NAME: PrintInventorySheetsOK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PrintInventorySheetsOK : IPrintInventorySheetsOK
	{
		readonly IApplicationDB appDB;
		
		
		public PrintInventorySheetsOK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrintInventorySheetsOKSp(Guid? PSessionID,
		string PWhse,
		int? PNumSheets,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			WhseType _PWhse = PWhse;
			IntType _PNumSheets = PNumSheets;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInventorySheetsOKSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNumSheets", _PNumSheets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
