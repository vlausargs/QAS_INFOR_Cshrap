//PROJECT NAME: Material
//CLASS NAME: ecniCheckGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IecniCheckGroup
	{
		(int? ReturnCode, byte? OutError) ecniCheckGroupSp(string InGroup,
		byte? OutError);
	}
	
	public class ecniCheckGroup : IecniCheckGroup
	{
		readonly IApplicationDB appDB;
		
		public ecniCheckGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? OutError) ecniCheckGroupSp(string InGroup,
		byte? OutError)
		{
			LongListType _InGroup = InGroup;
			FlagNyType _OutError = OutError;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ecniCheckGroupSp";
				
				appDB.AddCommandParameter(cmd, "InGroup", _InGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutError", _OutError, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutError = _OutError;
				
				return (Severity, OutError);
			}
		}
	}
}
