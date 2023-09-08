//PROJECT NAME: Production
//CLASS NAME: PmfHumanFriendlyName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfHumanFriendlyName : IPmfHumanFriendlyName
	{
		readonly IApplicationDB appDB;
		
		public PmfHumanFriendlyName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfHumanFriendlyNameFn(
			string Identifier)
		{
			StringType _Identifier = Identifier;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfHumanFriendlyName](@Identifier)";
				
				appDB.AddCommandParameter(cmd, "Identifier", _Identifier, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
