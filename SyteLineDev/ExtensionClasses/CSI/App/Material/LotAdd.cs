//PROJECT NAME: Material
//CLASS NAME: LotAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class LotAdd : ILotAdd
	{
		readonly IApplicationDB appDB;
		
		
		public LotAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LotAddSp(string Item,
		string Lot,
		decimal? RcvdQty,
		int? FromPO = 0,
		string VendLot = null,
		int? CreateNonUnique = 1,
		string Revision = null,
		string Infobar = null,
		string Site = null,
		DateTime? ManufacturedDate = null,
		DateTime? ExpirationDate = null,
		string LotTrxRestrictCode = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			QtyUnitType _RcvdQty = RcvdQty;
			ListYesNoType _FromPO = FromPO;
			VendLotType _VendLot = VendLot;
			ListYesNoType _CreateNonUnique = CreateNonUnique;
			RevisionType _Revision = Revision;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			DateType _ManufacturedDate = ManufacturedDate;
			DateType _ExpirationDate = ExpirationDate;
			TransRestrictionCodeType _LotTrxRestrictCode = LotTrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LotAddSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdQty", _RcvdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPO", _FromPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendLot", _VendLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateNonUnique", _CreateNonUnique, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturedDate", _ManufacturedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpirationDate", _ExpirationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTrxRestrictCode", _LotTrxRestrictCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
