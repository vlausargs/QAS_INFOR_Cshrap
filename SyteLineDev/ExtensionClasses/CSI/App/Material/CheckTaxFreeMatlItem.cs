//PROJECT NAME: Material
//CLASS NAME: CheckTaxFreeMatlItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CheckTaxFreeMatlItem : ICheckTaxFreeMatlItem
	{
		readonly IApplicationDB appDB;
		
		
		public CheckTaxFreeMatlItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DisableEnable) CheckTaxFreeMatlItemSp(string Item = null,
		string CallFrom = null,
		int? DisableEnable = null,
		string PSite = null)
		{
			ItemType _Item = Item;
			StringType _CallFrom = CallFrom;
			ListYesNoType _DisableEnable = DisableEnable;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckTaxFreeMatlItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisableEnable", _DisableEnable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DisableEnable = _DisableEnable;
				
				return (Severity, DisableEnable);
			}
		}

		public int? CheckTaxFreeMatlItemFn(
			string Item = null,
			string CallFrom = null,
			string PSite = null)
		{
			ItemType _Item = Item;
			StringType _CallFrom = CallFrom;
			SiteType _PSite = PSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckTaxFreeMatlItem](@Item, @CallFrom, @PSite)";

				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
