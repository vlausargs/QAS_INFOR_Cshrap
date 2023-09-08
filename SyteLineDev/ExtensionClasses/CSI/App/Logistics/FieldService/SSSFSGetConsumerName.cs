//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetConsumerName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetConsumerName : ISSSFSGetConsumerName
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetConsumerName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetConsumerNameFn(
			string UsrNum,
			int? UsrSeq)
		{
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetConsumerName](@UsrNum, @UsrSeq)";
				
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
