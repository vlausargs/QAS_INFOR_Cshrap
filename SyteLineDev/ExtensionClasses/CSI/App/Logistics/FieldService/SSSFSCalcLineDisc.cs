//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCalcLineDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCalcLineDisc : ISSSFSCalcLineDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCalcLineDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSCalcLineDiscFn(
			decimal? Amount,
			decimal? LineDisc,
			int? Places)
		{
			GenericDecimalType _Amount = Amount;
			LineDiscType _LineDisc = LineDisc;
			DecimalPlacesType _Places = Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSCalcLineDisc](@Amount, @LineDisc, @Places)";
				
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
