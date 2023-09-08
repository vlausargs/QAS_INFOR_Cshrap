//PROJECT NAME: Production
//CLASS NAME: PmfFixDec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFixDec : IPmfFixDec
	{
		readonly IApplicationDB appDB;
		
		public PmfFixDec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfFixDecFn(
			decimal? Number,
			int? Decimals)
		{
			DecimalType _Number = Number;
			IntType _Decimals = Decimals;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfFixDec](@Number, @Decimals)";
				
				appDB.AddCommandParameter(cmd, "Number", _Number, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decimals", _Decimals, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
