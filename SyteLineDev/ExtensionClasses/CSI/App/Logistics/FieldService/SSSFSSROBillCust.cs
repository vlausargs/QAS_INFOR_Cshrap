//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROBillCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROBillCust : ISSSFSSROBillCust
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROBillCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSSROBillCustFn(
			string SroNum,
			int? SroLine,
			int? SroOper)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSROBillCust](@SroNum, @SroLine, @SroOper)";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
