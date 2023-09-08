//PROJECT NAME: Material
//CLASS NAME: ItemAvailability.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemAvailability : IItemAvailability
	{
		readonly IApplicationDB appDB;
		
		
		public ItemAvailability(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? pQtyOnHandPhysical,
		decimal? pQtyOnHandAvailable,
		decimal? pQtyAllocCo,
		decimal? pQtyAllocMfg,
		decimal? pQtyOnOrder,
		decimal? pQtyWip,
		string Infobar) ItemAvailabilitySp(string pSite,
		string pItem,
		decimal? pQtyOnHandPhysical,
		decimal? pQtyOnHandAvailable,
		decimal? pQtyAllocCo,
		decimal? pQtyAllocMfg,
		decimal? pQtyOnOrder,
		decimal? pQtyWip,
		string Infobar)
		{
			SiteType _pSite = pSite;
			ItemType _pItem = pItem;
			QtyTotlType _pQtyOnHandPhysical = pQtyOnHandPhysical;
			QtyTotlType _pQtyOnHandAvailable = pQtyOnHandAvailable;
			QtyTotlType _pQtyAllocCo = pQtyAllocCo;
			QtyTotlType _pQtyAllocMfg = pQtyAllocMfg;
			QtyTotlType _pQtyOnOrder = pQtyOnOrder;
			QtyTotlType _pQtyWip = pQtyWip;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemAvailabilitySp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyOnHandPhysical", _pQtyOnHandPhysical, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pQtyOnHandAvailable", _pQtyOnHandAvailable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pQtyAllocCo", _pQtyAllocCo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pQtyAllocMfg", _pQtyAllocMfg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pQtyOnOrder", _pQtyOnOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pQtyWip", _pQtyWip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pQtyOnHandPhysical = _pQtyOnHandPhysical;
				pQtyOnHandAvailable = _pQtyOnHandAvailable;
				pQtyAllocCo = _pQtyAllocCo;
				pQtyAllocMfg = _pQtyAllocMfg;
				pQtyOnOrder = _pQtyOnOrder;
				pQtyWip = _pQtyWip;
				Infobar = _Infobar;
				
				return (Severity, pQtyOnHandPhysical, pQtyOnHandAvailable, pQtyAllocCo, pQtyAllocMfg, pQtyOnOrder, pQtyWip, Infobar);
			}
		}
	}
}
