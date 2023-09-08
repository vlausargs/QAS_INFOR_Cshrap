//PROJECT NAME: Data
//CLASS NAME: FTConvertPunchTypeFTtoSL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTConvertPunchTypeFTtoSL : IFTConvertPunchTypeFTtoSL
	{
		readonly IApplicationDB appDB;
		
		public FTConvertPunchTypeFTtoSL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTConvertPunchTypeFTtoSLFn(
			int? PunchType = null)
		{
			IntType _PunchType = PunchType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTConvertPunchTypeFTtoSL](@PunchType)";
				
				appDB.AddCommandParameter(cmd, "PunchType", _PunchType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
