//PROJECT NAME: Config
//CLASS NAME: CfgIPNCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgIPNCheck : ICfgIPNCheck
	{
		readonly IApplicationDB appDB;
		
		
		public CfgIPNCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pIpn,
		string pNewItem,
		string Infobar) CfgIPNCheckSp(string pConfigId,
		string pCEP,
		int? pIpn,
		string pNewItem,
		string CloneSite,
		string Infobar)
		{
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pCEP = pCEP;
			FlagNyType _pIpn = pIpn;
			ItemType _pNewItem = pNewItem;
			SiteType _CloneSite = CloneSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgIPNCheckSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCEP", _pCEP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIpn", _pIpn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pNewItem", _pNewItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CloneSite", _CloneSite, ParameterDirection.Input);
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
