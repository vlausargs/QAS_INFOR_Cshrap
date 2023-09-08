//PROJECT NAME: Logistics
//CLASS NAME: CoCustSeqValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoCustSeqValid : ICoCustSeqValid
	{
		readonly IApplicationDB appDB;
		
		
		public CoCustSeqValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ShipToAddress,
		string Whse,
		string ShipCode,
		int? ShipPartial,
		int? ShipEarly,
		string Slsman,
		string TaxCode1,
		string TaxCode2,
		string ShipToContact,
		string ShipToPhone,
		string Infobar,
		int? ShipHold) CoCustSeqValidSp(string CustNum,
		int? CustSeq,
		string ShipToAddress,
		string Whse,
		string ShipCode,
		int? ShipPartial,
		int? ShipEarly,
		string Slsman,
		string TaxCode1,
		string TaxCode2,
		string ShipToContact,
		string ShipToPhone,
		string Infobar,
		int? ShipHold)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			LongAddress _ShipToAddress = ShipToAddress;
			WhseType _Whse = Whse;
			ShipCodeType _ShipCode = ShipCode;
			Flag _ShipPartial = ShipPartial;
			Flag _ShipEarly = ShipEarly;
			SlsmanType _Slsman = Slsman;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ContactType _ShipToContact = ShipToContact;
			PhoneType _ShipToPhone = ShipToPhone;
			Infobar _Infobar = Infobar;
			Flag _ShipHold = ShipHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoCustSeqValidSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipPartial", _ShipPartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToContact", _ShipToContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToPhone", _ShipToPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipHold", _ShipHold, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipToAddress = _ShipToAddress;
				Whse = _Whse;
				ShipCode = _ShipCode;
				ShipPartial = _ShipPartial;
				ShipEarly = _ShipEarly;
				Slsman = _Slsman;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				ShipToContact = _ShipToContact;
				ShipToPhone = _ShipToPhone;
				Infobar = _Infobar;
				ShipHold = _ShipHold;
				
				return (Severity, ShipToAddress, Whse, ShipCode, ShipPartial, ShipEarly, Slsman, TaxCode1, TaxCode2, ShipToContact, ShipToPhone, Infobar, ShipHold);
			}
		}
	}
}
