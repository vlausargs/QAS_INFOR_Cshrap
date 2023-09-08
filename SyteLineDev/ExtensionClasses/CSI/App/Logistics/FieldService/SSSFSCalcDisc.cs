//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCalcDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCalcDisc : ISSSFSCalcDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCalcDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSCalcDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			decimal? LineDisc,
			int? Places)
		{
			GenericDecimalType _Amount = Amount;
			OrderDiscType _OrdDisc = OrdDisc;
			LineDiscType _LineDisc = LineDisc;
			DecimalPlacesType _Places = Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSCalcDisc](@Amount, @OrdDisc, @LineDisc, @Places)";
				
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdDisc", _OrdDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineDisc", _LineDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
