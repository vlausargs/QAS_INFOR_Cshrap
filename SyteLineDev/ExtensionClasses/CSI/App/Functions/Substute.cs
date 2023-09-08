//PROJECT NAME: Data
//CLASS NAME: Substute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Substute : ISubstute
	{
		readonly IApplicationDB appDB;
		
		public Substute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string POut) SubstuteSp(
			string PFmt,
			string PArgs,
			string POut,
			int? ConvertBlank = 0)
		{
			LongList _PFmt = PFmt;
			LongList _PArgs = PArgs;
			LongList _POut = POut;
			Flag _ConvertBlank = ConvertBlank;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SubstuteSp";
				
				appDB.AddCommandParameter(cmd, "PFmt", _PFmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArgs", _PArgs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POut", _POut, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConvertBlank", _ConvertBlank, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POut = _POut;
				
				return (Severity, POut);
			}
		}
	}
}
