//PROJECT NAME: Logistics
//CLASS NAME: RmaTP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaTP : IRmaTP
	{
		readonly IApplicationDB appDB;
		
		public RmaTP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RmaTPSp(
			string ParamRmaNum,
			int? ParamRmaLine,
			string ParamLoc,
			string ParamLot,
			decimal? ParamQty,
			int? ParamReturn,
			int? ParamRetToStock,
			DateTime? ParamTransDate,
			string ParamReasonCode,
			string ParamWorkkey,
			Guid? SessionID,
			string Infobar,
			string ParamImportDocId,
			decimal? ParamMatlCost = null,
			decimal? ParamLbrCost = null,
			decimal? ParamFovhdCost = null,
			decimal? ParamVovhdCost = null,
			decimal? ParamOutCost = null,
			string ContainerNum = null,
			string ParamDocumentNum = null)
		{
			RmaNumType _ParamRmaNum = ParamRmaNum;
			RmaLineType _ParamRmaLine = ParamRmaLine;
			LocType _ParamLoc = ParamLoc;
			LotType _ParamLot = ParamLot;
			QtyUnitType _ParamQty = ParamQty;
			ListYesNoType _ParamReturn = ParamReturn;
			ListYesNoType _ParamRetToStock = ParamRetToStock;
			DateType _ParamTransDate = ParamTransDate;
			ReasonCodeType _ParamReasonCode = ParamReasonCode;
			LongListType _ParamWorkkey = ParamWorkkey;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ParamImportDocId = ParamImportDocId;
			CostPrcType _ParamMatlCost = ParamMatlCost;
			CostPrcType _ParamLbrCost = ParamLbrCost;
			CostPrcType _ParamFovhdCost = ParamFovhdCost;
			CostPrcType _ParamVovhdCost = ParamVovhdCost;
			CostPrcType _ParamOutCost = ParamOutCost;
			ContainerType _ContainerNum = ContainerNum;
			DocumentNumType _ParamDocumentNum = ParamDocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaTPSp";
				
				appDB.AddCommandParameter(cmd, "ParamRmaNum", _ParamRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRmaLine", _ParamRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLoc", _ParamLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLot", _ParamLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamQty", _ParamQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamReturn", _ParamReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRetToStock", _ParamRetToStock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamTransDate", _ParamTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamReasonCode", _ParamReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamWorkkey", _ParamWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParamImportDocId", _ParamImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamMatlCost", _ParamMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLbrCost", _ParamLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamFovhdCost", _ParamFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamVovhdCost", _ParamVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamOutCost", _ParamOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamDocumentNum", _ParamDocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
