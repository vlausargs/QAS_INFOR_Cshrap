//PROJECT NAME: Data
//CLASS NAME: GetValueAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetValueAddress : IGetValueAddress
	{
		readonly IApplicationDB appDB;
		
		public GetValueAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PValue) GetValueAddressSp(
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
				cmd.CommandText = "GetValueAddressSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIndex", _PIndex, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PValue", _PValue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PValue = _PValue;
				
				return (Severity, PValue);
			}
		}
	}
}
