//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroHasPostedTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroHasPostedTrans : ISSSFSSroHasPostedTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroHasPostedTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSroHasPostedTransFn(
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
				cmd.CommandText = "SELECT  dbo.[SSSFSSroHasPostedTrans](@SroNum, @SroLine, @SroOper)";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
