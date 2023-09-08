//PROJECT NAME: Data
//CLASS NAME: FTConvertPunchTypeSLtoFT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTConvertPunchTypeSLtoFT : IFTConvertPunchTypeSLtoFT
	{
		readonly IApplicationDB appDB;
		
		public FTConvertPunchTypeSLtoFT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTConvertPunchTypeSLtoFTFn(
			int? PunchType = null)
		{
			IntType _PunchType = PunchType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTConvertPunchTypeSLtoFT](@PunchType)";
				
				appDB.AddCommandParameter(cmd, "PunchType", _PunchType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
