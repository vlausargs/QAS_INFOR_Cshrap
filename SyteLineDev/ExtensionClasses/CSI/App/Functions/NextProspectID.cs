//PROJECT NAME: Data
//CLASS NAME: NextProspectID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextProspectID : INextProspectID
	{
		readonly IApplicationDB appDB;
		
		public NextProspectID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Key,
			string Infobar) NextProspectIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar)
		{
			LongListType _Context = Context;
			LongListType _Prefix = Prefix;
			IntType _KeyLength = KeyLength;
			LongListType _Key = Key;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextProspectIDSp";
				
				appDB.AddCommandParameter(cmd, "Context", _Context, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				Infobar = _Infobar;
				
				return (Severity, Key, Infobar);
			}
		}
	}
}
