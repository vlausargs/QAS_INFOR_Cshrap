//PROJECT NAME: Production
//CLASS NAME: PmfConvertWtUmBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfConvertWtUmBase : IPmfConvertWtUmBase
	{
		readonly IApplicationDB appDB;
		
		public PmfConvertWtUmBase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PmfConvertWtUmBaseFn(
			string item)
		{
			StringType _item = item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfConvertWtUmBase](@item)";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
