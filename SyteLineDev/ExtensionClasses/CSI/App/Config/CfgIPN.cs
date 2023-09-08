//PROJECT NAME: Config
//CLASS NAME: CfgIPN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgIPN : ICfgIPN
	{
		readonly IApplicationDB appDB;
		
		public CfgIPN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pIpn,
			string pNewItem,
			string Infobar) CfgIPNSp(
			string pCfgItem,
			string pConfigId,
			string pFirst,
			string pSecond,
			int? pIpn,
			string pNewItem,
			string Infobar)
		{
			ItemType _pCfgItem = pCfgItem;
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pFirst = pFirst;
			LongListType _pSecond = pSecond;
			FlagNyType _pIpn = pIpn;
			ItemType _pNewItem = pNewItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgIPNSp";
				
				appDB.AddCommandParameter(cmd, "pCfgItem", _pCfgItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFirst", _pFirst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSecond", _pSecond, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIpn", _pIpn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pNewItem", _pNewItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pIpn = _pIpn;
				pNewItem = _pNewItem;
				Infobar = _Infobar;
				
				return (Severity, pIpn, pNewItem, Infobar);
			}
		}
	}
}
