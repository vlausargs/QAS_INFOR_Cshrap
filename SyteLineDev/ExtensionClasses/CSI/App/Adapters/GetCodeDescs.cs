//PROJECT NAME: Adapters
//CLASS NAME: GetCodeDescs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Adapters
{
	public class GetCodeDescs : IGetCodeDescs
	{
		readonly IApplicationDB appDB;
		
		
		public GetCodeDescs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PCodeDescs) GetCodeDescsSp(string PClass,
		string PCharCodes = null,
		string PDelimiter = null,
		string PCodeDescs = null)
		{
			ComboClassType _PClass = PClass;
			InfobarType _PCharCodes = PCharCodes;
			InfobarType _PDelimiter = PDelimiter;
			InfobarType _PCodeDescs = PCodeDescs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCodeDescsSp";
				
				appDB.AddCommandParameter(cmd, "PClass", _PClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCharCodes", _PCharCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelimiter", _PDelimiter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCodeDescs", _PCodeDescs, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCodeDescs = _PCodeDescs;
				
				return (Severity, PCodeDescs);
			}
		}

		public string GetCodeDescsFn(
			string PClass,
			string PCharCodes = null,
			string PDelimiter = null)
		{
			ComboClassType _PClass = PClass;
			InfobarType _PCharCodes = PCharCodes;
			InfobarType _PDelimiter = PDelimiter;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCodeDescs](@PClass, @PCharCodes, @PDelimiter)";

				appDB.AddCommandParameter(cmd, "PClass", _PClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCharCodes", _PCharCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelimiter", _PDelimiter, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
