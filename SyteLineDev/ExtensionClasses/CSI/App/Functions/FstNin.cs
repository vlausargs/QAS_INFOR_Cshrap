//PROJECT NAME: Data
//CLASS NAME: FstNin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FstNin : IFstNin
	{
		readonly IApplicationDB appDB;
		
		public FstNin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Pos) FstNinSp(
			string Source,
			string Valid,
			int? Pos)
		{
			LongList _Source = Source;
			LongList _Valid = Valid;
			GenericIntType _Pos = Pos;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FstNinSp";
				
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Valid", _Valid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pos", _Pos, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Pos = _Pos;
				
				return (Severity, Pos);
			}
		}
	}
}
