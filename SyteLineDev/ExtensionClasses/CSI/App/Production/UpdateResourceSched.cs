//PROJECT NAME: Production
//CLASS NAME: UpdateResourceSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class UpdateResourceSched : IUpdateResourceSched
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateResourceSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateResourceSchedSp(int? SequenceNum,
		int? JobTag,
		string GroupID)
		{
			ApsIntType _SequenceNum = SequenceNum;
			ApsOperationTagType _JobTag = JobTag;
			ApsResgroupType _GroupID = GroupID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateResourceSchedSp";
				
				appDB.AddCommandParameter(cmd, "SequenceNum", _SequenceNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTag", _JobTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupID", _GroupID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
