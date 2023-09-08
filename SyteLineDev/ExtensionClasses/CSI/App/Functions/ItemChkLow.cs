//PROJECT NAME: Data
//CLASS NAME: ItemChkLow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemChkLow : IItemChkLow
	{
		readonly IApplicationDB appDB;
		
		public ItemChkLow(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemChkLowSp(
			string ChkItem,
			string Infobar)
		{
			ItemType _ChkItem = ChkItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemChkLowSp";
				
				appDB.AddCommandParameter(cmd, "ChkItem", _ChkItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
