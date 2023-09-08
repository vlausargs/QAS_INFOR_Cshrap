//PROJECT NAME: Data
//CLASS NAME: GetReplDocLastManualPublishDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetReplDocLastManualPublishDate : IGetReplDocLastManualPublishDate
	{
		readonly IApplicationDB appDB;
		
		public GetReplDocLastManualPublishDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetReplDocLastManualPublishDateFn(
			string AppliesToIDOName,
			string AppliesToIDOAction,
			string AppliesToIDOMethodName)
		{
			CollectionNameType _AppliesToIDOName = AppliesToIDOName;
			CollectionActionType _AppliesToIDOAction = AppliesToIDOAction;
			MethodNameType _AppliesToIDOMethodName = AppliesToIDOMethodName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetReplDocLastManualPublishDate](@AppliesToIDOName, @AppliesToIDOAction, @AppliesToIDOMethodName)";
				
				appDB.AddCommandParameter(cmd, "AppliesToIDOName", _AppliesToIDOName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppliesToIDOAction", _AppliesToIDOAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppliesToIDOMethodName", _AppliesToIDOMethodName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
