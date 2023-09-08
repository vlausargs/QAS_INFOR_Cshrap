//PROJECT NAME: Production
//CLASS NAME: PmfGetBomJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetBomJob : IPmfGetBomJob
	{
		readonly IApplicationDB appDB;
		
		public PmfGetBomJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? PmfGetBomJobFn(
			string Item,
			int? BomSource)
		{
			ItemType _Item = Item;
			IntType _BomSource = BomSource;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetBomJob](@Item, @BomSource)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSource", _BomSource, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
