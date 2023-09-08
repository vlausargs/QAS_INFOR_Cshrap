//PROJECT NAME: Data
//CLASS NAME: UseInventoryConsignedFromVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseInventoryConsignedFromVendor : IUseInventoryConsignedFromVendor
	{
		readonly IApplicationDB appDB;
		
		public UseInventoryConsignedFromVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UseInventoryConsignedFromVendorSp(
			string CurrentWhse,
			string JobmatlItem = null,
			decimal? ConsignQtyRequired = null,
			string UM = null,
			string BackFlushLoc = null,
			string Infobar = null)
		{
			WhseType _CurrentWhse = CurrentWhse;
			ItemType _JobmatlItem = JobmatlItem;
			QtyTotlType _ConsignQtyRequired = ConsignQtyRequired;
			UMType _UM = UM;
			LocType _BackFlushLoc = BackFlushLoc;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UseInventoryConsignedFromVendorSp";
				
				appDB.AddCommandParameter(cmd, "CurrentWhse", _CurrentWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignQtyRequired", _ConsignQtyRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackFlushLoc", _BackFlushLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
