//PROJECT NAME: Material
//CLASS NAME: EcniDeleteGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class EcniDeleteGroup : IEcniDeleteGroup
	{
		readonly IApplicationDB appDB;
		
		
		public EcniDeleteGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EcniDeleteGroupSp(string InGroup,
		string InDelStd,
		string InDelJob,
		string InDelEst)
		{
			LongListType _InGroup = InGroup;
			LongListType _InDelStd = InDelStd;
			LongListType _InDelJob = InDelJob;
			LongListType _InDelEst = InDelEst;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcniDeleteGroupSp";
				
				appDB.AddCommandParameter(cmd, "InGroup", _InGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InDelStd", _InDelStd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InDelJob", _InDelJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InDelEst", _InDelEst, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
