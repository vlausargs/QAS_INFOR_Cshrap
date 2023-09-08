//PROJECT NAME: Material
//CLASS NAME: ConsignUsageGetLotAndLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ConsignUsageGetLotAndLoc : IConsignUsageGetLotAndLoc
	{
		readonly IApplicationDB appDB;
		
		
		public ConsignUsageGetLotAndLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Loc,
		string Lot,
		string ImportDocId,
		string TrxRestrictCode) ConsignUsageGetLotAndLocSp(string CurrWhse,
		string Item,
		string ConsignWhse,
		string ConsignLoc,
		string Loc,
		string Lot,
		string ImportDocId,
		string TrxRestrictCode)
		{
			WhseType _CurrWhse = CurrWhse;
			ItemType _Item = Item;
			WhseType _ConsignWhse = ConsignWhse;
			LocType _ConsignLoc = ConsignLoc;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ImportDocIdType _ImportDocId = ImportDocId;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConsignUsageGetLotAndLocSp";
				
				appDB.AddCommandParameter(cmd, "CurrWhse", _CurrWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignWhse", _ConsignWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignLoc", _ConsignLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Loc = _Loc;
				Lot = _Lot;
				ImportDocId = _ImportDocId;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, Loc, Lot, ImportDocId, TrxRestrictCode);
			}
		}
	}
}
