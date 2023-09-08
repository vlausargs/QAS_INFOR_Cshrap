//PROJECT NAME: Logistics
//CLASS NAME: DeleteTmpSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class DeleteTmpSer : IDeleteTmpSer
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteTmpSer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteTmpSerSp(Guid? TmpSerId)
		{
			RowPointerType _TmpSerId = TmpSerId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTmpSerSp";
				
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
