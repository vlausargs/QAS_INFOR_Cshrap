//PROJECT NAME: Data
//CLASS NAME: NextEj.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextEj : INextEj
	{
		readonly IApplicationDB appDB;
		
		public NextEj(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PKey,
			string Infobar) NextEjSp(
			string PContext,
			string PPrefix,
			int? PKeyLength,
			string PKey,
			string Infobar)
		{
			LongListType _PContext = PContext;
			LongListType _PPrefix = PPrefix;
			GenericIntType _PKeyLength = PKeyLength;
			JobType _PKey = PKey;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextEjSp";
				
				appDB.AddCommandParameter(cmd, "PContext", _PContext, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrefix", _PPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKeyLength", _PKeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKey", _PKey, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PKey = _PKey;
				Infobar = _Infobar;
				
				return (Severity, PKey, Infobar);
			}
		}
	}
}
