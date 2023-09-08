//PROJECT NAME: POS
//CLASS NAME: SSSPOSCalcOneDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCalcOneDisc : ISSSPOSCalcOneDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCalcOneDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSPOSCalcOneDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			int? Places)
		{
			GenericDecimalType _Amount = Amount;
			OrderDiscType _OrdDisc = OrdDisc;
			DecimalPlacesType _Places = Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSPOSCalcOneDisc](@Amount, @OrdDisc, @Places)";
				
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdDisc", _OrdDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
