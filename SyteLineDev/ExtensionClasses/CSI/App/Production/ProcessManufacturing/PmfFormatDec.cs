//PROJECT NAME: Production
//CLASS NAME: PmfFormatDec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFormatDec : IPmfFormatDec
	{
		readonly IApplicationDB appDB;
		
		public PmfFormatDec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfFormatDecFn(
			decimal? Value,
			int? MaxDecimals)
		{
			DecimalType _Value = Value;
			IntType _MaxDecimals = MaxDecimals;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfFormatDec](@Value, @MaxDecimals)";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxDecimals", _MaxDecimals, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
