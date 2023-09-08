//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCalcHdrDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCalcHdrDisc : ISSSFSCalcHdrDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCalcHdrDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSCalcHdrDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			int? Places)
		{
			AmountType _Amount = Amount;
			OrderDiscType _OrdDisc = OrdDisc;
			DecimalPlacesType _Places = Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSCalcHdrDisc](@Amount, @OrdDisc, @Places)";
				
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdDisc", _OrdDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
