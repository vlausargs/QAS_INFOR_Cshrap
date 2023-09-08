//PROJECT NAME: Config
//CLASS NAME: CfgUpdateConfigGid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgUpdateConfigGid : ICfgUpdateConfigGid
	{
		readonly IApplicationDB appDB;
		
		
		public CfgUpdateConfigGid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgUpdateConfigGidSp(string pRecType,
		string pKey1,
		string pKey2,
		string pKey3,
		string pConfigGid)
		{
			StringType _pRecType = pRecType;
			StringType _pKey1 = pKey1;
			StringType _pKey2 = pKey2;
			StringType _pKey3 = pKey3;
			ConfigGIDType _pConfigGid = pConfigGid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgUpdateConfigGidSp";
				
				appDB.AddCommandParameter(cmd, "pRecType", _pRecType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey1", _pKey1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey2", _pKey2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey3", _pKey3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigGid", _pConfigGid, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
