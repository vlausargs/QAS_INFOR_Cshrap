//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroGetDerValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroGetDerValue : ISSSFSSroGetDerValue
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroGetDerValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSSroGetDerValueFn(
			string SroNum,
			string InParm)
		{
			FSSRONumType _SroNum = SroNum;
			StringType _InParm = InParm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSroGetDerValue](@SroNum, @InParm)";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InParm", _InParm, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
