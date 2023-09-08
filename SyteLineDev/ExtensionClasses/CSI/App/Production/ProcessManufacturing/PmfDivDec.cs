//PROJECT NAME: Production
//CLASS NAME: PmfDivDec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfDivDec : IPmfDivDec
	{
		readonly IApplicationDB appDB;
		
		public PmfDivDec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfDivDecFn(
			decimal? num,
			decimal? den)
		{
			DecimalType _num = num;
			DecimalType _den = den;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfDivDec](@num, @den)";
				
				appDB.AddCommandParameter(cmd, "num", _num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "den", _den, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
