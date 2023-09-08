//PROJECT NAME: CSIMaterial
//CLASS NAME: CategoryActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICategoryActive
	{
		int CategoryActiveSp(string ItemCategory,
		                     byte? Active,
		                     ref string Infobar);
	}
	
	public class CategoryActive : ICategoryActive
	{
		readonly IApplicationDB appDB;
		
		public CategoryActive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CategoryActiveSp(string ItemCategory,
		                            byte? Active,
		                            ref string Infobar)
		{
			ItemCategoryType _ItemCategory = ItemCategory;
			ListYesNoType _Active = Active;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CategoryActiveSp";
				
				appDB.AddCommandParameter(cmd, "ItemCategory", _ItemCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
