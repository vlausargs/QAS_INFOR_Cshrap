//PROJECT NAME: Data
//CLASS NAME: IsCategoryInHierarchy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsCategoryInHierarchy : IIsCategoryInHierarchy
	{
		readonly IApplicationDB appDB;
		
		public IsCategoryInHierarchy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsCategoryInHierarchyFn(
			string ItemCategory)
		{
			ItemCategoryType _ItemCategory = ItemCategory;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsCategoryInHierarchy](@ItemCategory)";
				
				appDB.AddCommandParameter(cmd, "ItemCategory", _ItemCategory, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
