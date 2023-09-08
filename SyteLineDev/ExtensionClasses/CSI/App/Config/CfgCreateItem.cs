//PROJECT NAME: Config
//CLASS NAME: CfgCreateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCreateItem : ICfgCreateItem
	{
		readonly IApplicationDB appDB;
		
		public CfgCreateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgCreateItemSp(
			string pBaseItem,
			string pNewItem,
			int? pItemExists,
			string pConfigId,
			int? RepRemote,
			string Infobar)
		{
			ItemType _pBaseItem = pBaseItem;
			ItemType _pNewItem = pNewItem;
			FlagNyType _pItemExists = pItemExists;
			ConfigIdType _pConfigId = pConfigId;
			FlagNyType _RepRemote = RepRemote;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCreateItemSp";
				
				appDB.AddCommandParameter(cmd, "pBaseItem", _pBaseItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewItem", _pNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemExists", _pItemExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepRemote", _RepRemote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
