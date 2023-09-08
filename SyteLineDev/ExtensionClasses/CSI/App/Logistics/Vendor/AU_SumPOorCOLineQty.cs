//PROJECT NAME: Logistics
//CLASS NAME: AU_SumPOorCOLineQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_SumPOorCOLineQty : IAU_SumPOorCOLineQty
	{
		readonly IApplicationDB appDB;
		
		public AU_SumPOorCOLineQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? AU_SumPOorCOLineQtyFn(
			string POorCONum,
			int? POorCoLine,
			string CalcType,
			string CalcColumnType)
		{
			PoNumType _POorCONum = POorCONum;
			PoLineType _POorCoLine = POorCoLine;
			StringType _CalcType = CalcType;
			StringType _CalcColumnType = CalcColumnType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[AU_SumPOorCOLineQty](@POorCONum, @POorCoLine, @CalcType, @CalcColumnType)";
				
				appDB.AddCommandParameter(cmd, "POorCONum", _POorCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POorCoLine", _POorCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcType", _CalcType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcColumnType", _CalcColumnType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
