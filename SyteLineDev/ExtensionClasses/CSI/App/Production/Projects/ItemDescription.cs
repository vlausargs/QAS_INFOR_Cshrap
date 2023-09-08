//PROJECT NAME: CSIProjects
//CLASS NAME: ItemDescription.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IItemDescription
	{
		int ItemDescriptionSp(string Item,
		                      ref string Description,
		                      ref decimal? UnitWeight,
		                      ref string UM);
	}
	
	public class ItemDescription : IItemDescription
	{
		readonly IApplicationDB appDB;
		
		public ItemDescription(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ItemDescriptionSp(string Item,
		                             ref string Description,
		                             ref decimal? UnitWeight,
		                             ref string UM)
		{
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UnitWeightType _UnitWeight = UnitWeight;
			UMType _UM = UM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemDescriptionSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				UnitWeight = _UnitWeight;
				UM = _UM;
				
				return Severity;
			}
		}
	}
}
