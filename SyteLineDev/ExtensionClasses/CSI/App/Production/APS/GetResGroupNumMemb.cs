//PROJECT NAME: Production
//CLASS NAME: GetResGroupNumMemb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IGetResGroupNumMemb
	{
		(int? ReturnCode, int? NumOfMembers) GetResGroupNumMembSp(string ResourceGroupId,
		int? NumOfMembers);
	}
	
	public class GetResGroupNumMemb : IGetResGroupNumMemb
	{
		readonly IApplicationDB appDB;
		
		public GetResGroupNumMemb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NumOfMembers) GetResGroupNumMembSp(string ResourceGroupId,
		int? NumOfMembers)
		{
			ApsResgroupType _ResourceGroupId = ResourceGroupId;
			GenericNoType _NumOfMembers = NumOfMembers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetResGroupNumMembSp";
				
				appDB.AddCommandParameter(cmd, "ResourceGroupId", _ResourceGroupId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumOfMembers", _NumOfMembers, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NumOfMembers = _NumOfMembers;
				
				return (Severity, NumOfMembers);
			}
		}
	}
}
