//PROJECT NAME: Production
//CLASS NAME: PP_GetFormulaStrings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetFormulaStrings : IPP_GetFormulaStrings
	{
		readonly IApplicationDB appDB;
		
		
		public PP_GetFormulaStrings(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PropertyString) PP_GetFormulaStringsSp(string CollectionName,
		string OperationType,
		string PropertyName,
		string PropertyString)
		{
			StringType _CollectionName = CollectionName;
			PP_OperationType2Type _OperationType = OperationType;
			StringType _PropertyName = PropertyName;
			StringType _PropertyString = PropertyString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GetFormulaStringsSp";
				
				appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationType", _OperationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PropertyName", _PropertyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PropertyString", _PropertyString, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PropertyString = _PropertyString;
				
				return (Severity, PropertyString);
			}
		}
	}
}
