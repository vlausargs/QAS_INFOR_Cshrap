//PROJECT NAME: DataCollection
//CLASS NAME: DcAMiscirSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAMiscirSub : IDcAMiscirSub
	{
		readonly IApplicationDB appDB;
		
		public DcAMiscirSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcAMiscirSubSp(
			string TTermId,
			string pEmpNum,
			DateTime? TTransDate,
			string pTransType,
			string pItem,
			string pLocation,
			string pLot,
			string pCurWhse,
			decimal? pQty,
			string pUm,
			string pReasonCode,
			string pDocumentNum)
		{
			DcTermIdType _TTermId = TTermId;
			EmpNumType _pEmpNum = pEmpNum;
			DateTimeType _TTransDate = TTransDate;
			DcTransTypeType _pTransType = pTransType;
			ItemType _pItem = pItem;
			LocType _pLocation = pLocation;
			LotType _pLot = pLot;
			WhseType _pCurWhse = pCurWhse;
			QtyUnitType _pQty = pQty;
			UMType _pUm = pUm;
			ReasonCodeType _pReasonCode = pReasonCode;
			DocumentNumType _pDocumentNum = pDocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAMiscirSubSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransType", _pTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLocation", _pLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLot", _pLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurWhse", _pCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQty", _pQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUm", _pUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReasonCode", _pReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDocumentNum", _pDocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
