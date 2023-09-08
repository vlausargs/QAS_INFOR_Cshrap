//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemCategoryHierarchyCurrentSearch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetItemCategoryHierarchyCurrentSearch
	{
		int GetItemCategoryHierarchyCurrentSearchSp(Guid? RowPointer,
		                                            ref string CurrentSearch);
	}
	
	public class GetItemCategoryHierarchyCurrentSearch : IGetItemCategoryHierarchyCurrentSearch
	{
		readonly IApplicationDB appDB;
		
		public GetItemCategoryHierarchyCurrentSearch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetItemCategoryHierarchyCurrentSearchSp(Guid? RowPointer,
		                                                   ref string CurrentSearch)
		{
			RowPointerType _RowPointer = RowPointer;
			StringType _CurrentSearch = CurrentSearch;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemCategoryHierarchyCurrentSearchSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentSearch", _CurrentSearch, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrentSearch = _CurrentSearch;
				
				return Severity;
			}
		}
	}
}
