//PROJECT NAME: Production
//CLASS NAME: ApsPrecisionQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPrecisionQty : IApsPrecisionQty
	{
		readonly IApplicationDB appDB;
		
		public ApsPrecisionQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsPrecisionQtyFn(
			decimal? pQty,
			int? pPrecision,
			int? pUpFlag)
		{
			QtyTotlType _pQty = pQty;
			DecimalPlacesType _pPrecision = pPrecision;
			ListYesNoType _pUpFlag = pUpFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPrecisionQty](@pQty, @pPrecision, @pUpFlag)";
				
				appDB.AddCommandParameter(cmd, "pQty", _pQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrecision", _pPrecision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpFlag", _pUpFlag, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
