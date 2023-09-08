//PROJECT NAME: Data
//CLASS NAME: GetPortalCustomerAndOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPortalCustomerAndOrderInfo : IGetPortalCustomerAndOrderInfo
	{
		readonly IApplicationDB appDB;
		
		public GetPortalCustomerAndOrderInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? CoRowPointer,
			int? CustSeq,
			string CustName,
			int? B2B,
			string CoType,
			string CurrCode,
			string CoNum,
			string PaymentMethod,
			string ShippingMethod,
			Guid? CustomerCatalogRowPointer,
			string Infobar) GetPortalCustomerAndOrderInfoSp(
			string CustNum,
			Guid? CoRowPointer,
			int? CustSeq,
			string CustName,
			int? B2B,
			string CoType,
			string CurrCode,
			string CoNum,
			string PaymentMethod,
			string ShippingMethod,
			Guid? CustomerCatalogRowPointer,
			string Infobar)
		{
			CustNumType _CustNum = CustNum;
			RowPointerType _CoRowPointer = CoRowPointer;
			CustSeqType _CustSeq = CustSeq;
			NameType _CustName = CustName;
			ListYesNoType _B2B = B2B;
			CoTypeType _CoType = CoType;
			CurrCodeType _CurrCode = CurrCode;
			CoNumType _CoNum = CoNum;
			PaymentMethodType _PaymentMethod = PaymentMethod;
			ShipMethodType _ShippingMethod = ShippingMethod;
			RowPointerType _CustomerCatalogRowPointer = CustomerCatalogRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPortalCustomerAndOrderInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "B2B", _B2B, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentMethod", _PaymentMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShippingMethod", _ShippingMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustomerCatalogRowPointer", _CustomerCatalogRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoRowPointer = _CoRowPointer;
				CustSeq = _CustSeq;
				CustName = _CustName;
				B2B = _B2B;
				CoType = _CoType;
				CurrCode = _CurrCode;
				CoNum = _CoNum;
				PaymentMethod = _PaymentMethod;
				ShippingMethod = _ShippingMethod;
				CustomerCatalogRowPointer = _CustomerCatalogRowPointer;
				Infobar = _Infobar;
				
				return (Severity, CoRowPointer, CustSeq, CustName, B2B, CoType, CurrCode, CoNum, PaymentMethod, ShippingMethod, CustomerCatalogRowPointer, Infobar);
			}
		}
	}
}
