//PROJECT NAME: POS
//CLASS NAME: SSSPOSCalcDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCalcDisc : ISSSPOSCalcDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCalcDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSPOSCalcDiscFn(
			decimal? P_amount,
			decimal? P_ord_disc,
			decimal? P_line_disc,
			int? P_Places)
		{
			AmountType _P_amount = P_amount;
			FSPctType _P_ord_disc = P_ord_disc;
			FSPctType _P_line_disc = P_line_disc;
			GenericIntType _P_Places = P_Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSPOSCalcDisc](@P_amount, @P_ord_disc, @P_line_disc, @P_Places)";
				
				appDB.AddCommandParameter(cmd, "P_amount", _P_amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_ord_disc", _P_ord_disc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_line_disc", _P_line_disc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Places", _P_Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
