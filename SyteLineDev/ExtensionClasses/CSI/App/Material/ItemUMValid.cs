//PROJECT NAME: Material
//CLASS NAME: ItemUMValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemUMValid : IItemUMValid
	{
		readonly IApplicationDB appDB;
		
		
		public ItemUMValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PUM,
		decimal? UomConvFactor,
		string Infobar) ItemUMValidSp(string PItem,
		string PUM,
		decimal? UomConvFactor,
		string Infobar)
		{
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemUMValidSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUM = _PUM;
				UomConvFactor = _UomConvFactor;
				Infobar = _Infobar;
				
				return (Severity, PUM, UomConvFactor, Infobar);
			}
		}
	}
}
