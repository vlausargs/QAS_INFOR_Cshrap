//PROJECT NAME: DataCollection
//CLASS NAME: DcATrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcATrans : IDcATrans
	{
		readonly IApplicationDB appDB;
		
		
		public DcATrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) DcATransSp(string pTermId,
		string TTransType,
		string pEmpNum,
		DateTime? pTransDate,
		string pTransfer,
		int? pLine,
		string pUM,
		decimal? pQty,
		string pLoc,
		string pLot,
		string pTrnLot,
		string pRemoteSiteTrnLotProcess,
		int? pUseExistingSerials,
		string InfoBar)
		{
			DcTermIdType _pTermId = pTermId;
			DcTransTypeType _TTransType = TTransType;
			EmpNumType _pEmpNum = pEmpNum;
			DateType _pTransDate = pTransDate;
			TrnNumType _pTransfer = pTransfer;
			TrnLineType _pLine = pLine;
			UMType _pUM = pUM;
			QtyUnitType _pQty = pQty;
			LocType _pLoc = pLoc;
			LotType _pLot = pLot;
			LotType _pTrnLot = pTrnLot;
			ListExistingCreateBothType _pRemoteSiteTrnLotProcess = pRemoteSiteTrnLotProcess;
			ListYesNoType _pUseExistingSerials = pUseExistingSerials;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcATransSp";
				
				appDB.AddCommandParameter(cmd, "pTermId", _pTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransType", _TTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransfer", _pTransfer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLine", _pLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUM", _pUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQty", _pQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLoc", _pLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLot", _pLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnLot", _pTrnLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRemoteSiteTrnLotProcess", _pRemoteSiteTrnLotProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseExistingSerials", _pUseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
