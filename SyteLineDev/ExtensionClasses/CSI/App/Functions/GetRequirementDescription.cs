//PROJECT NAME: Data
//CLASS NAME: GetRequirementDescription.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetRequirementDescription : IGetRequirementDescription
	{
		readonly IApplicationDB appDB;
		
		public GetRequirementDescription(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetRequirementDescriptionFn(
			string ReqType,
			string Requirement)
		{
			PosReqTypeType _ReqType = ReqType;
			PosRequirementType _Requirement = Requirement;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetRequirementDescription](@ReqType, @Requirement)";
				
				appDB.AddCommandParameter(cmd, "ReqType", _ReqType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Requirement", _Requirement, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
