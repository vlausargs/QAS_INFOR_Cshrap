//PROJECT NAME: Data
//CLASS NAME: EXTSSSPOSUobChcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSPOSUobChcr : IEXTSSSPOSUobChcr
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSPOSUobChcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSPOSUobChcrFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EXTSSSPOSUobChcr](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
