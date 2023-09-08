//PROJECT NAME: Data
//CLASS NAME: LotAddRemote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LotAddRemote : ILotAddRemote
	{
		readonly IApplicationDB appDB;
		
		public LotAddRemote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LotAddRemoteSp(
			string Item,
			string Lot,
			decimal? RcvdQty,
			string VendLot,
			string Revision = null,
			DateTime? ManufacturedDate = null,
			DateTime? ExpirationDate = null,
			string LotTrxRestrictCode = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			QtyUnitType _RcvdQty = RcvdQty;
			VendLotType _VendLot = VendLot;
			RevisionType _Revision = Revision;
			DateType _ManufacturedDate = ManufacturedDate;
			DateType _ExpirationDate = ExpirationDate;
			TransRestrictionCodeType _LotTrxRestrictCode = LotTrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LotAddRemoteSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdQty", _RcvdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendLot", _VendLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturedDate", _ManufacturedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpirationDate", _ExpirationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTrxRestrictCode", _LotTrxRestrictCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
