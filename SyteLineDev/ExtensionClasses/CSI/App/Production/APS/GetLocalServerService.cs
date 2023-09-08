//PROJECT NAME: Production
//CLASS NAME: GetLocalServerService.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class GetLocalServerService : IGetLocalServerService
	{
		readonly IApplicationDB appDB;
		
		
		public GetLocalServerService(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pServerName,
		int? pPortNo) GetLocalServerServiceSp(int? AltNo,
		string pServerName,
		int? pPortNo)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsHostnameType _pServerName = pServerName;
			ApsPortType _pPortNo = pPortNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLocalServerServiceSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pServerName", _pServerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pPortNo", _pPortNo, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pServerName = _pServerName;
				pPortNo = _pPortNo;
				
				return (Severity, pServerName, pPortNo);
			}
		}
	}
}
