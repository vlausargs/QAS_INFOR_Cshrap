//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipHdr_Upd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipHdr_Upd : ISSSFSSROPackSlipHdr_Upd
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROPackSlipHdr_Upd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PackNum) SSSFSSROPackSlipHdr_UpdSp(Guid? RowPointer,
		int? Selected,
		int? PackNum,
		string Whse,
		DateTime? PackDate,
		string CustNum,
		string DropType,
		string DropPartnerID,
		string DropCustNum,
		string DropUsrNum,
		string DropShipNo,
		int? DropCustSeq,
		int? DropUsrSeq,
		decimal? Weight,
		string ShipCode,
		int? QtyPackages)
		{
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _Selected = Selected;
			PackNumType _PackNum = PackNum;
			WhseType _Whse = Whse;
			DateType _PackDate = PackDate;
			CustNumType _CustNum = CustNum;
			FSDropShipTypeType _DropType = DropType;
			FSPartnerType _DropPartnerID = DropPartnerID;
			CustNumType _DropCustNum = DropCustNum;
			FSUsrNumType _DropUsrNum = DropUsrNum;
			DropShipNoType _DropShipNo = DropShipNo;
			DropSeqType _DropCustSeq = DropCustSeq;
			DropSeqType _DropUsrSeq = DropUsrSeq;
			WeightType _Weight = Weight;
			ShipCodeType _ShipCode = ShipCode;
			PackagesType _QtyPackages = QtyPackages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROPackSlipHdr_UpdSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropType", _DropType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropPartnerID", _DropPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropCustNum", _DropCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropUsrNum", _DropUsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropCustSeq", _DropCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropUsrSeq", _DropUsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PackNum = _PackNum;
				
				return (Severity, PackNum);
			}
		}
	}
}
