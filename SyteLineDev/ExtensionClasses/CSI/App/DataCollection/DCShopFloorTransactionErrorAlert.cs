//PROJECT NAME: DataCollection
//CLASS NAME: DCShopFloorTransactionErrorAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DCShopFloorTransactionErrorAlert : IDCShopFloorTransactionErrorAlert
	{
		readonly IApplicationDB appDB;
		
		public DCShopFloorTransactionErrorAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DCShopFloorTransactionErrorAlertSp(
			int? ErrorCount,
			string Infobar)
		{
			IntType _ErrorCount = ErrorCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DCShopFloorTransactionErrorAlertSp";
				
				appDB.AddCommandParameter(cmd, "ErrorCount", _ErrorCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
