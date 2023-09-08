//PROJECT NAME: Data
//CLASS NAME: NextResourceMaintID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextResourceMaintID : INextResourceMaintID
	{
		readonly IApplicationDB appDB;
		
		public NextResourceMaintID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Key,
			string Infobar) NextResourceMaintIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar,
			string RESID = null)
		{
			LongListType _Context = Context;
			LongListType _Prefix = Prefix;
			IntType _KeyLength = KeyLength;
			LongListType _Key = Key;
			InfobarType _Infobar = Infobar;
			ApsResourceType _RESID = RESID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextResourceMaintIDSp";
				
				appDB.AddCommandParameter(cmd, "Context", _Context, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				Infobar = _Infobar;
				
				return (Severity, Key, Infobar);
			}
		}
	}
}
