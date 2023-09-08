//PROJECT NAME: Production
//CLASS NAME: PP_OperTypeCodeAccessForProperty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_OperTypeCodeAccessForProperty : IPP_OperTypeCodeAccessForProperty
	{
		readonly IApplicationDB appDB;
		
		public PP_OperTypeCodeAccessForProperty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PP_OperTypeCodeAccessForPropertyFn(
			string CollectionName,
			string PropertyName)
		{
			StringType _CollectionName = CollectionName;
			StringType _PropertyName = PropertyName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PP_OperTypeCodeAccessForProperty](@CollectionName, @PropertyName)";
				
				appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PropertyName", _PropertyName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
