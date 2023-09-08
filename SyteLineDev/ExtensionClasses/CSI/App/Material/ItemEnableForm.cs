//PROJECT NAME: Material
//CLASS NAME: ItemEnableForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemEnableForm : IItemEnableForm
	{
		readonly IApplicationDB appDB;
		
		
		public ItemEnableForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? use_wholesale_price,
		int? use_backflush) ItemEnableFormSp(int? use_wholesale_price,
		int? use_backflush,
		string PSite = null)
		{
			ListYesNoType _use_wholesale_price = use_wholesale_price;
			ListYesNoType _use_backflush = use_backflush;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemEnableFormSp";
				
				appDB.AddCommandParameter(cmd, "use_wholesale_price", _use_wholesale_price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "use_backflush", _use_backflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				use_wholesale_price = _use_wholesale_price;
				use_backflush = _use_backflush;
				
				return (Severity, use_wholesale_price, use_backflush);
			}
		}
	}
}
