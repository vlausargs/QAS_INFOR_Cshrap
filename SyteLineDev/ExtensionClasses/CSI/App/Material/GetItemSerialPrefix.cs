//PROJECT NAME: Material
//CLASS NAME: GetItemSerialPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetItemSerialPrefix : IGetItemSerialPrefix
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemSerialPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pItemSerialPrefix,
		string rInfobar) GetItemSerialPrefixSp(string pItem,
		string pSite,
		string pItemSerialPrefix,
		string rInfobar)
		{
			ItemType _pItem = pItem;
			SiteType _pSite = pSite;
			SerialPrefixType _pItemSerialPrefix = pItemSerialPrefix;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemSerialPrefixSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemSerialPrefix", _pItemSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pItemSerialPrefix = _pItemSerialPrefix;
				rInfobar = _rInfobar;
				
				return (Severity, pItemSerialPrefix, rInfobar);
			}
		}
	}
}
