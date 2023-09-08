//PROJECT NAME: Logistics
//CLASS NAME: DeletePickListRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DeletePickListRef : IDeletePickListRef
	{
		readonly IApplicationDB appDB;
		
		
		public DeletePickListRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeletePickListRefSp(decimal? PickListId,
		Guid? RefRowPointer,
		string Infobar)
		{
			PickListIDType _PickListId = PickListId;
			RowPointerType _RefRowPointer = RefRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeletePickListRefSp";
				
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
