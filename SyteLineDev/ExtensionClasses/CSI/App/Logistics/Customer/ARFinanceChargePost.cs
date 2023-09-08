//PROJECT NAME: Logistics
//CLASS NAME: ARFinanceChargePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARFinanceChargePost : IARFinanceChargePost
	{
		readonly IApplicationDB appDB;
		
		
		public ARFinanceChargePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ARFinanceChargePostSp(Guid? PSessionID,
		string PCustNum,
		Guid? PJHeaderRowPointer,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			CustNumType _PCustNum = PCustNum;
			RowPointerType _PJHeaderRowPointer = PJHeaderRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARFinanceChargePostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJHeaderRowPointer", _PJHeaderRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
