//PROJECT NAME: Data
//CLASS NAME: ProdMixIrtSyncNeeded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProdMixIrtSyncNeeded : IProdMixIrtSyncNeeded
	{
		readonly IApplicationDB appDB;
		
		public ProdMixIrtSyncNeeded(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProdMixIrtSyncNeededFn(
			string ProdMix,
			DateTime? Today)
		{
			ProdMixType _ProdMix = ProdMix;
			DateTimeType _Today = Today;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ProdMixIrtSyncNeeded](@ProdMix, @Today)";
				
				appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Today", _Today, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
