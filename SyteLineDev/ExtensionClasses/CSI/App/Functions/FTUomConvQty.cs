//PROJECT NAME: Data
//CLASS NAME: FTUomConvQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTUomConvQty : IFTUomConvQty
	{
		readonly IApplicationDB appDB;
		
		public FTUomConvQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FTUomConvQtyFn(
			decimal? QtyToBeConverted,
			decimal? UomConvFactor,
			string FromBase)
		{
			QtyUnitType _QtyToBeConverted = QtyToBeConverted;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			StringType _FromBase = FromBase;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTUomConvQty](@QtyToBeConverted, @UomConvFactor, @FromBase)";
				
				appDB.AddCommandParameter(cmd, "QtyToBeConverted", _QtyToBeConverted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromBase", _FromBase, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
