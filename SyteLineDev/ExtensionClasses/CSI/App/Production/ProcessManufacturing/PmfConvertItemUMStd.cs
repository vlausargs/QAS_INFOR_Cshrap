//PROJECT NAME: Production
//CLASS NAME: PmfConvertItemUMStd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfConvertItemUMStd : IPmfConvertItemUMStd
	{
		readonly IApplicationDB appDB;
		
		public PmfConvertItemUMStd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfConvertItemUMStdFn(
			string FromUM,
			string ToUM,
			decimal? Density,
			string Item)
		{
			StringType _FromUM = FromUM;
			StringType _ToUM = ToUM;
			DecimalType _Density = Density;
			StringType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfConvertItemUMStd](@FromUM, @ToUM, @Density, @Item)";
				
				appDB.AddCommandParameter(cmd, "FromUM", _FromUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToUM", _ToUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Density", _Density, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
