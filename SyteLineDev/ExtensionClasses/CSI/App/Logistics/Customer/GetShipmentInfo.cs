//PROJECT NAME: CSICustomer
//CLASS NAME: GetShipmentInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetShipmentInfo
	{
		int GetShipmentInfoSp(decimal? ShipmentId,
		                      ref string Status,
		                      ref string CustNum,
		                      ref int? CustSeq,
		                      ref string Whse,
		                      ref string ShipCode,
		                      ref string CurrCode,
		                      ref string Infobar);
	}
	
	public class GetShipmentInfo : IGetShipmentInfo
	{
		readonly IApplicationDB appDB;
		
		public GetShipmentInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetShipmentInfoSp(decimal? ShipmentId,
		                             ref string Status,
		                             ref string CustNum,
		                             ref int? CustSeq,
		                             ref string Whse,
		                             ref string ShipCode,
		                             ref string CurrCode,
		                             ref string Infobar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentStatusType _Status = Status;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			ShipCodeType _ShipCode = ShipCode;
			CurrCodeType _CurrCode = CurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetShipmentInfoSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Status = _Status;
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				Whse = _Whse;
				ShipCode = _ShipCode;
				CurrCode = _CurrCode;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
