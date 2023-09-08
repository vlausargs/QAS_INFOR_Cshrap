//PROJECT NAME: Data
//CLASS NAME: GetInteractionStartedBy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetInteractionStartedBy : IGetInteractionStartedBy
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionStartedBy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetInteractionStartedByFn(
			decimal? InteractionId)
		{
			InteractionIdType _InteractionId = InteractionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetInteractionStartedBy](@InteractionId)";
				
				appDB.AddCommandParameter(cmd, "InteractionId", _InteractionId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
