//PROJECT NAME: Data
//CLASS NAME: SSSPostAdjInvCst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSPostAdjInvCst : ISSSPostAdjInvCst
	{
		readonly IApplicationDB appDB;
		
		public SSSPostAdjInvCst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPostAdjInvCstSp(
			decimal? iInvQty,
			DateTime? iPostDate,
			decimal? iSum,
			string iCustNum,
			string iItem,
			string iWhse,
			string iLoc,
			string iLot,
			decimal? iMatltranTransNum,
			decimal? iMatltranMatlCost,
			decimal? iMatltranLbrCost,
			decimal? iMatltranFovhdCost,
			decimal? iMatltranVovhdCost,
			decimal? iMatltranOutCost,
			decimal? iMatltranCost,
			string iJournalId,
			int? iPreUpdateQtys,
			string iReference,
			string Infobar)
		{
			QtyUnitType _iInvQty = iInvQty;
			DateType _iPostDate = iPostDate;
			QtyUnitType _iSum = iSum;
			CustNumType _iCustNum = iCustNum;
			ItemType _iItem = iItem;
			WhseType _iWhse = iWhse;
			LocType _iLoc = iLoc;
			LotType _iLot = iLot;
			MatlTransNumType _iMatltranTransNum = iMatltranTransNum;
			CostPrcType _iMatltranMatlCost = iMatltranMatlCost;
			CostPrcType _iMatltranLbrCost = iMatltranLbrCost;
			CostPrcType _iMatltranFovhdCost = iMatltranFovhdCost;
			CostPrcType _iMatltranVovhdCost = iMatltranVovhdCost;
			CostPrcType _iMatltranOutCost = iMatltranOutCost;
			CostPrcType _iMatltranCost = iMatltranCost;
			JournalIdType _iJournalId = iJournalId;
			ListYesNoType _iPreUpdateQtys = iPreUpdateQtys;
			ReferenceType _iReference = iReference;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPostAdjInvCstSp";
				
				appDB.AddCommandParameter(cmd, "iInvQty", _iInvQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPostDate", _iPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSum", _iSum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLoc", _iLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLot", _iLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranTransNum", _iMatltranTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranMatlCost", _iMatltranMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranLbrCost", _iMatltranLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranFovhdCost", _iMatltranFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranVovhdCost", _iMatltranVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranOutCost", _iMatltranOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatltranCost", _iMatltranCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iJournalId", _iJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPreUpdateQtys", _iPreUpdateQtys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iReference", _iReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
