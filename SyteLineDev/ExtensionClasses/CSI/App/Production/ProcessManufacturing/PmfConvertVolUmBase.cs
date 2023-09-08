//PROJECT NAME: Production
//CLASS NAME: PmfConvertVolUmBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfConvertVolUmBase : IPmfConvertVolUmBase
	{
		readonly IApplicationDB appDB;
		
		public PmfConvertVolUmBase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfConvertVolUmBaseFn(
			string item)
		{
			StringType _item = item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfConvertVolUmBase](@item)";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
