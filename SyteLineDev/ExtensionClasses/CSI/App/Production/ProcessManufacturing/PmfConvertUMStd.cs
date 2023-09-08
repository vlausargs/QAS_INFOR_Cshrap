//PROJECT NAME: Production
//CLASS NAME: PmfConvertUMStd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfConvertUMStd : IPmfConvertUMStd
	{
		readonly IApplicationDB appDB;
		
		public PmfConvertUMStd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfConvertUMStdFn(
			string FromUM,
			string ToUM,
			decimal? Density)
		{
			StringType _FromUM = FromUM;
			StringType _ToUM = ToUM;
			DecimalType _Density = Density;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfConvertUMStd](@FromUM, @ToUM, @Density)";
				
				appDB.AddCommandParameter(cmd, "FromUM", _FromUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToUM", _ToUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Density", _Density, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
