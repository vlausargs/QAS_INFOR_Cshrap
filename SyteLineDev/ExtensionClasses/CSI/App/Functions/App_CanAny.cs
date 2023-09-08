//PROJECT NAME: Data
//CLASS NAME: App_CanAny.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_CanAny : IApp_CanAny
	{
		readonly IApplicationDB appDB;
		
		public App_CanAny(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? App_CanAnyFn(
			string Type,
			string FormName)
		{
			LongList _Type = Type;
			AuthorizationObjectNameType _FormName = FormName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[App_CanAny](@Type, @FormName)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
