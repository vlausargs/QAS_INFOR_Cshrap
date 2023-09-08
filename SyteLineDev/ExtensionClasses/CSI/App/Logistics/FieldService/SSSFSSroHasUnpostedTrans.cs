//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroHasUnpostedTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroHasUnpostedTrans : ISSSFSSroHasUnpostedTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroHasUnpostedTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSroHasUnpostedTransFn(
			string SroNum,
			int? SroLine = null,
			int? SroOper = null)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSroHasUnpostedTrans](@SroNum, @SroLine, @SroOper)";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
