//PROJECT NAME: Data
//CLASS NAME: CopyCustomerNotesToCO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyCustomerNotesToCO : ICopyCustomerNotesToCO
	{
		readonly IApplicationDB appDB;
		
		public CopyCustomerNotesToCO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CopyCustomerNotesToCOSp(
			Guid? CORowPointer,
			string CustNum,
			string Infobar)
		{
			RowPointerType _CORowPointer = CORowPointer;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyCustomerNotesToCOSp";
				
				appDB.AddCommandParameter(cmd, "CORowPointer", _CORowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
