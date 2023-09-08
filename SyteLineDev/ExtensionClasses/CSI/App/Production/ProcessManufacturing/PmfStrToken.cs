//PROJECT NAME: Production
//CLASS NAME: PmfStrToken.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfStrToken : IPmfStrToken
	{
		readonly IApplicationDB appDB;
		
		public PmfStrToken(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfStrTokenFn(
			string str,
			string delim,
			int? findN)
		{
			StringType _string = str;
			StringType _delim = delim;
			IntType _findN = findN;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfStrToken](@string, @delim, @findN)";
				
				appDB.AddCommandParameter(cmd, "string", _string, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "delim", _delim, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "findN", _findN, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
