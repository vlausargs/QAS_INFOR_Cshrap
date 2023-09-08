//PROJECT NAME: Data
//CLASS NAME: SetValueAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetValueAddress : ISetValueAddress
	{
		readonly IApplicationDB appDB;
		
		public SetValueAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PText) SetValueAddressSp(
			string PText,
			int? PIndex,
			string PValue)
		{
			StringType _PText = PText;
			IntType _PIndex = PIndex;
			StringType _PValue = PValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetValueAddressSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PIndex", _PIndex, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PValue", _PValue, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PText = _PText;
				
				return (Severity, PText);
			}
		}
	}
}
