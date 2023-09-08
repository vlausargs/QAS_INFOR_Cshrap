//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetCustPortalOrderInfo
	{
		int GetCustPortalOrderInfoSp(string CustNum,
		                             byte? ResellerPortalFlag,
		                             string ResellerCustNum,
		                             ref Guid? CoRowPointer,
		                             ref int? CustSeq,
		                             ref string CustName,
		                             ref byte? B2B,
		                             ref string CoType,
		                             ref string CurrCode,
		                             ref string CoNum,
		                             ref string PaymentMethod,
		                             ref string ShippingMethod,
		                             ref Guid? CustomerCatalogRowPointer,
		                             ref decimal? SubTotal,
		                             ref decimal? SalesTax,
		                             ref decimal? ShippingCost,
		                             ref int? ItemCnt,
		                             ref decimal? CommissionAmountTotal,
		                             ref string Infobar);
	}
	
	public class GetCustPortalOrderInfo : IGetCustPortalOrderInfo
	{
		readonly IApplicationDB appDB;
		
		public GetCustPortalOrderInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetCustPortalOrderInfoSp(string CustNum,
		                                    byte? ResellerPortalFlag,
		                                    string ResellerCustNum,
		                                    ref Guid? CoRowPointer,
		                                    ref int? CustSeq,
		                                    ref string CustName,
		                                    ref byte? B2B,
		                                    ref string CoType,
		                                    ref string CurrCode,
		                                    ref string CoNum,
		                                    ref string PaymentMethod,
		                                    ref string ShippingMethod,
		                                    ref Guid? CustomerCatalogRowPointer,
		                                    ref decimal? SubTotal,
		                                    ref decimal? SalesTax,
		                                    ref decimal? ShippingCost,
		                                    ref int? ItemCnt,
		                                    ref decimal? CommissionAmountTotal,
		                                    ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _ResellerPortalFlag = ResellerPortalFlag;
			CustNumType _ResellerCustNum = ResellerCustNum;
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
			AmountType _SubTotal = SubTotal;
			AmountType _SalesTax = SalesTax;
			AmountType _ShippingCost = ShippingCost;
			IntType _ItemCnt = ItemCnt;
			AmountType _CommissionAmountTotal = CommissionAmountTotal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustPortalOrderInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerPortalFlag", _ResellerPortalFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCustNum", _ResellerCustNum, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "SubTotal", _SubTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShippingCost", _ShippingCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCnt", _ItemCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommissionAmountTotal", _CommissionAmountTotal, ParameterDirection.InputOutput);
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
				SubTotal = _SubTotal;
				SalesTax = _SalesTax;
				ShippingCost = _ShippingCost;
				ItemCnt = _ItemCnt;
				CommissionAmountTotal = _CommissionAmountTotal;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
