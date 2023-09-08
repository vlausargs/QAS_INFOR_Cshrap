//PROJECT NAME: Data
//CLASS NAME: CustaddrUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CustaddrUpd : ICustaddrUpd
	{
		readonly IApplicationDB appDB;
		
		public CustaddrUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) CustaddrUpdSP(
			string CustNum,
			int? CustSeq,
			decimal? AmtOverInvAmt = null,
			string BalMethod = null,
			string BillToEmail = null,
			int? CorpAddress = 0,
			int? CorpCred = 0,
			string CorpCust = null,
			int? CreditHold = 0,
			DateTime? CreditHoldDate = null,
			string CreditHoldReason = null,
			string CreditHoldUser = null,
			decimal? CreditLimit = null,
			decimal? OrderCreditLimit = null,
			string CurrCode = null,
			int? DaysOverInvDueDate = null,
			string ExternalEmailAddr = null,
			string FaxNum = null,
			string InternalEmailAddr = null,
			string InternetUrl = null,
			string ShipToEmail = null,
			string TelexNum = null,
			string Addr_1 = null,
			string Addr_2 = null,
			string Addr_3 = null,
			string Addr_4 = null,
			string City = null,
			string Country = null,
			string County = null,
			string Name = null,
			string State = null,
			string Zip = null,
			int? UseLongName = 0,
			string LongName = null,
			int? FromShipTos = 0,
			string InfoBar = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			AmountType _AmtOverInvAmt = AmtOverInvAmt;
			BalMethodType _BalMethod = BalMethod;
			EmailType _BillToEmail = BillToEmail;
			ListYesNoType _CorpAddress = CorpAddress;
			ListYesNoType _CorpCred = CorpCred;
			CustNumType _CorpCust = CorpCust;
			ListYesNoType _CreditHold = CreditHold;
			DateType _CreditHoldDate = CreditHoldDate;
			ReasonCodeType _CreditHoldReason = CreditHoldReason;
			UserCodeType _CreditHoldUser = CreditHoldUser;
			AmountType _CreditLimit = CreditLimit;
			AmountType _OrderCreditLimit = OrderCreditLimit;
			CurrCodeType _CurrCode = CurrCode;
			DaysOverType _DaysOverInvDueDate = DaysOverInvDueDate;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			PhoneType _FaxNum = FaxNum;
			EmailType _InternalEmailAddr = InternalEmailAddr;
			URLType _InternetUrl = InternetUrl;
			EmailType _ShipToEmail = ShipToEmail;
			PhoneType _TelexNum = TelexNum;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			CityType _City = City;
			CountryType _Country = Country;
			CountyType _County = County;
			NameType _Name = Name;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			ListYesNoType _UseLongName = UseLongName;
			LongNameType _LongName = LongName;
			ListYesNoType _FromShipTos = FromShipTos;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustaddrUpdSP";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtOverInvAmt", _AmtOverInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalMethod", _BalMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToEmail", _BillToEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpAddress", _CorpAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCred", _CorpCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldDate", _CreditHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldReason", _CreditHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldUser", _CreditHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditLimit", _CreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderCreditLimit", _OrderCreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysOverInvDueDate", _DaysOverInvDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternalEmailAddr", _InternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternetUrl", _InternetUrl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToEmail", _ShipToEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseLongName", _UseLongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongName", _LongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromShipTos", _FromShipTos, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
