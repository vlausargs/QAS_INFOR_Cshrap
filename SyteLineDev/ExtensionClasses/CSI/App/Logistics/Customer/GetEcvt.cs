//PROJECT NAME: Logistics
//CLASS NAME: GetEcvt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetEcvt : IGetEcvt
	{
		readonly IApplicationDB appDB;
		
		
		public GetEcvt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EcCode,
		string Transport,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string ShipSite) GetEcvtSp(string CustNum,
		int? CustSeq,
		string Shipcode,
		string EcCode,
		string Transport,
		int? SupplQtyReq = 0,
		decimal? SupplQtyConvFactor = 1M,
		string CoLcrNum = null,
		string ShipSite = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ShipCodeType _Shipcode = Shipcode;
			EcCodeType _EcCode = EcCode;
			TransportType _Transport = Transport;
			ListYesNoType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			LcrNumType _CoLcrNum = CoLcrNum;
			SiteType _ShipSite = ShipSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEcvtSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shipcode", _Shipcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Transport", _Transport, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLcrNum", _CoLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EcCode = _EcCode;
				Transport = _Transport;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				ShipSite = _ShipSite;
				
				return (Severity, EcCode, Transport, SupplQtyReq, SupplQtyConvFactor, ShipSite);
			}
		}
	}
}
