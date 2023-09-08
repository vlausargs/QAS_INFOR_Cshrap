//PROJECT NAME: MOIndPack
//CLASS NAME: MO_ResourceJobDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_ResourceJobDelete : IMO_ResourceJobDelete
	{
		readonly IApplicationDB appDB;
		
		
		public MO_ResourceJobDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_ResourceJobDeleteSp(int? DeleteFlag,
		string RESID)
		{
			ListYesNoType _DeleteFlag = DeleteFlag;
			ApsResourceType _RESID = RESID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ResourceJobDeleteSp";
				
				appDB.AddCommandParameter(cmd, "DeleteFlag", _DeleteFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
