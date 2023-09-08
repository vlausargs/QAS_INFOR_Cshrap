//PROJECT NAME: Data
//CLASS NAME: RefSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RefSet : IRefSet
	{
		readonly IApplicationDB appDB;
		
		public RefSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string RefSetSp(
			string JobOrdType,
			string JobOrdNum,
			int? JobOrdLine,
			int? JobOrdRelease)
		{
			RefTypeIKOTType _JobOrdType = JobOrdType;
			CoProjTrnNumType _JobOrdNum = JobOrdNum;
			CoProjTaskTrnLineType _JobOrdLine = JobOrdLine;
			CoReleaseType _JobOrdRelease = JobOrdRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RefSetSp](@JobOrdType, @JobOrdNum, @JobOrdLine, @JobOrdRelease)";
				
				appDB.AddCommandParameter(cmd, "JobOrdType", _JobOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobOrdNum", _JobOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobOrdLine", _JobOrdLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobOrdRelease", _JobOrdRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
