//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCoCustomerValid2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSCoCustomerValid2
    {
        int SSSPOSCoCustomerValid2Sp(string OldCustNum,
                                     ref string CustNum,
                                     ref int? CustSeq,
                                     ref string BillToAddress,
                                     ref string ShipToAddress,
                                     ref string Contact,
                                     ref string Phone,
                                     ref string BillToContact,
                                     ref string BillToPhone,
                                     ref string ShipToContact,
                                     ref string ShipToPhone,
                                     ref string ShipCode,
                                     ref string TermsCode,
                                     ref string PriceCode,
                                     string TaxCode1Type,
                                     ref string TaxCode1,
                                     string TaxCode2Type,
                                     ref string TaxCode2,
                                     ref byte? OnCreditHold,
                                     ref string Slsman,
                                     ref string EndUserType,
                                     ref string Infobar);
    }

    public class SSSPOSCoCustomerValid2 : ISSSPOSCoCustomerValid2
    {
        readonly IApplicationDB appDB;

        public SSSPOSCoCustomerValid2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSCoCustomerValid2Sp(string OldCustNum,
                                            ref string CustNum,
                                            ref int? CustSeq,
                                            ref string BillToAddress,
                                            ref string ShipToAddress,
                                            ref string Contact,
                                            ref string Phone,
                                            ref string BillToContact,
                                            ref string BillToPhone,
                                            ref string ShipToContact,
                                            ref string ShipToPhone,
                                            ref string ShipCode,
                                            ref string TermsCode,
                                            ref string PriceCode,
                                            string TaxCode1Type,
                                            ref string TaxCode1,
                                            string TaxCode2Type,
                                            ref string TaxCode2,
                                            ref byte? OnCreditHold,
                                            ref string Slsman,
                                            ref string EndUserType,
                                            ref string Infobar)
        {
            CustNumType _OldCustNum = OldCustNum;
            CustNumType _CustNum = CustNum;
            CustSeqType _CustSeq = CustSeq;
            LongAddress _BillToAddress = BillToAddress;
            LongAddress _ShipToAddress = ShipToAddress;
            ContactType _Contact = Contact;
            PhoneType _Phone = Phone;
            ContactType _BillToContact = BillToContact;
            PhoneType _BillToPhone = BillToPhone;
            ContactType _ShipToContact = ShipToContact;
            PhoneType _ShipToPhone = ShipToPhone;
            ShipCodeType _ShipCode = ShipCode;
            TermsCodeType _TermsCode = TermsCode;
            PriceCodeType _PriceCode = PriceCode;
            LongListType _TaxCode1Type = TaxCode1Type;
            TaxCodeType _TaxCode1 = TaxCode1;
            LongListType _TaxCode2Type = TaxCode2Type;
            TaxCodeType _TaxCode2 = TaxCode2;
            ListYesNoType _OnCreditHold = OnCreditHold;
            SlsmanType _Slsman = Slsman;
            EndUserTypeType _EndUserType = EndUserType;
            LongListType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSCoCustomerValid2Sp";

                appDB.AddCommandParameter(cmd, "OldCustNum", _OldCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillToContact", _BillToContact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillToPhone", _BillToPhone, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToContact", _ShipToContact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToPhone", _ShipToPhone, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1Type", _TaxCode1Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2Type", _TaxCode2Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OnCreditHold", _OnCreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CustNum = _CustNum;
                CustSeq = _CustSeq;
                BillToAddress = _BillToAddress;
                ShipToAddress = _ShipToAddress;
                Contact = _Contact;
                Phone = _Phone;
                BillToContact = _BillToContact;
                BillToPhone = _BillToPhone;
                ShipToContact = _ShipToContact;
                ShipToPhone = _ShipToPhone;
                ShipCode = _ShipCode;
                TermsCode = _TermsCode;
                PriceCode = _PriceCode;
                TaxCode1 = _TaxCode1;
                TaxCode2 = _TaxCode2;
                OnCreditHold = _OnCreditHold;
                Slsman = _Slsman;
                EndUserType = _EndUserType;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
