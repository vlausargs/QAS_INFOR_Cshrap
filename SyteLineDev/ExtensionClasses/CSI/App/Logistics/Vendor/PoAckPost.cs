//PROJECT NAME: Logistics
//CLASS NAME: PoAckPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoAckPost : IPoAckPost
	{
		readonly IApplicationDB appDB;
		
		
		public PoAckPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PoAckPostSp(Guid? PoackRowPointer,
		Guid? VendTpRowPointer,
		string Infobar)
		{
			RowPointerType _PoackRowPointer = PoackRowPointer;
			RowPointerType _VendTpRowPointer = VendTpRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoAckPostSp";
				
				appDB.AddCommandParameter(cmd, "PoackRowPointer", _PoackRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendTpRowPointer", _VendTpRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
