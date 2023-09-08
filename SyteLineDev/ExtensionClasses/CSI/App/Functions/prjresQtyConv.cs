//PROJECT NAME: Data
//CLASS NAME: prjresQtyConv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class prjresQtyConv : IprjresQtyConv
	{
		readonly IApplicationDB appDB;
		
		public prjresQtyConv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? prjresQtyConvFn(
			string PUM,
			string PItem,
			decimal? PQty,
			string Site = null)
		{
			UMType _PUM = PUM;
			ItemType _PItem = PItem;
			QtyPerType _PQty = PQty;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[prjresQtyConv](@PUM, @PItem, @PQty, @Site)";
				
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
