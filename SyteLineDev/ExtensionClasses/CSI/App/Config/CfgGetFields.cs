//PROJECT NAME: Config
//CLASS NAME: CfgGetFields.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetFields : ICfgGetFields
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetFields(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgGetFieldsSp(string pFile,
		int? pInclude)
		{
			LongListType _pFile = pFile;
			FlagNyType _pInclude = pInclude;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetFieldsSp";
				
				appDB.AddCommandParameter(cmd, "pFile", _pFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInclude", _pInclude, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
