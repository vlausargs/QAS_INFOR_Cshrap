//PROJECT NAME: CSICodes
//CLASS NAME: GetResellerCreatedCustomerCO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetResellerCreatedCustomerCO
	{
		int GetResellerCreatedCustomerCOSp(string CustNum,
		                                   string Username,
		                                   ref int? CustSeq,
		                                   ref Guid? CoRowPointer,
		                                   ref string CoNum,
		                                   ref byte? B2B,
		                                   ref string CurrCode,
		                                   ref string CoType,
		                                   ref string PaymentMethod,
		                                   ref string ShippingMethod,
		                                   ref string Infobar);
	}
	
	public class GetResellerCreatedCustomerCO : IGetResellerCreatedCustomerCO
	{
		readonly IApplicationDB appDB;
		
		public GetResellerCreatedCustomerCO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetResellerCreatedCustomerCOSp(string CustNum,
		                                          string Username,
		                                          ref int? CustSeq,
		                                          ref Guid? CoRowPointer,
		                                          ref string CoNum,
		                                          ref byte? B2B,
		                                          ref string CurrCode,
		                                          ref string CoType,
		                                          ref string PaymentMethod,
		                                          ref string ShippingMethod,
		                                          ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			UsernameType _Username = Username;
			CustSeqType _CustSeq = CustSeq;
			RowPointerType _CoRowPointer = CoRowPointer;
			CoNumType _CoNum = CoNum;
			ListYesNoType _B2B = B2B;
			CurrCodeType _CurrCode = CurrCode;
			CoTypeType _CoType = CoType;
			PaymentMethodType _PaymentMethod = PaymentMethod;
			ShipMethodType _ShippingMethod = ShippingMethod;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetResellerCreatedCustomerCOSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "B2B", _B2B, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentMethod", _PaymentMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShippingMethod", _ShippingMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				CoRowPointer = _CoRowPointer;
				CoNum = _CoNum;
				B2B = _B2B;
				CurrCode = _CurrCode;
				CoType = _CoType;
				PaymentMethod = _PaymentMethod;
				ShippingMethod = _ShippingMethod;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
