//PROJECT NAME: Data
//CLASS NAME: DeleteItemCategoryHierarchy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteItemCategoryHierarchy : IDeleteItemCategoryHierarchy
	{
		readonly IApplicationDB appDB;
		
		public DeleteItemCategoryHierarchy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteItemCategoryHierarchySp(
			Guid? DelRowPointer)
		{
			RowPointerType _DelRowPointer = DelRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteItemCategoryHierarchySp";
				
				appDB.AddCommandParameter(cmd, "DelRowPointer", _DelRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
