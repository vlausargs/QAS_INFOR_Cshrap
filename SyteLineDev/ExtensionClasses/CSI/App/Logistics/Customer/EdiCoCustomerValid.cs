//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoCustomerValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCoCustomerValid
    {
        int EdiCoCustomerValidSp(string CoNum,
                                 string OldCustNum,
                                 Guid? RowPointer,
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
                                 ref string CorpCust,
                                 ref string CorpCustName,
                                 ref string CorpCustContact,
                                 ref string CorpCustPhone,
                                 ref byte? CorpAddress,
                                 ref string CurrCode,
                                 ref byte? UseExchRate,
                                 ref string Whse,
                                 ref string ShipCode,
                                 ref string ShipCodeDesc,
                                 ref byte? ShipPartial,
                                 ref byte? ShipEarly,
                                 ref string TermsCode,
                                 ref string TermsCodeDesc,
                                 ref string Slsman,
                                 ref string PriceCode,
                                 ref string PriceCodeDesc,
                                 ref string TaxCode1,
                                 ref string TaxCode1Desc,
                                 ref string TaxCode2,
                                 ref string TaxCode2Desc,
                                 ref string TransNat,
                                 ref string TransNat2,
                                 ref string Delterm,
                                 ref string ProcessInd,
                                 ref byte? CreditHoldFlag,
                                 ref string Infobar);
    }

    public class EdiCoCustomerValid : IEdiCoCustomerValid
    {
        readonly IApplicationDB appDB;

        public EdiCoCustomerValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCoCustomerValidSp(string CoNum,
                                        string OldCustNum,
                                        Guid? RowPointer,
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
                                        ref string CorpCust,
                                        ref string CorpCustName,
                                        ref string CorpCustContact,
                                        ref string CorpCustPhone,
                                        ref byte? CorpAddress,
                                        ref string CurrCode,
                                        ref byte? UseExchRate,
                                        ref string Whse,
                                        ref string ShipCode,
                                        ref string ShipCodeDesc,
                                        ref byte? ShipPartial,
                                        ref byte? ShipEarly,
                                        ref string TermsCode,
                                        ref string TermsCodeDesc,
                                        ref string Slsman,
                                        ref string PriceCode,
                                        ref string PriceCodeDesc,
                                        ref string TaxCode1,
                                        ref string TaxCode1Desc,
                                        ref string TaxCode2,
                                        ref string TaxCode2Desc,
                                        ref string TransNat,
                                        ref string TransNat2,
                                        ref string Delterm,
                                        ref string ProcessInd,
                                        ref byte? CreditHoldFlag,
                                        ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            CustNumType _OldCustNum = OldCustNum;
            RowPointerType _RowPointer = RowPointer;
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
            CustNumType _CorpCust = CorpCust;
            NameType _CorpCustName = CorpCustName;
            ContactType _CorpCustContact = CorpCustContact;
            PhoneType _CorpCustPhone = CorpCustPhone;
            Flag _CorpAddress = CorpAddress;
            CurrCodeType _CurrCode = CurrCode;
            Flag _UseExchRate = UseExchRate;
            WhseType _Whse = Whse;
            ShipCodeType _ShipCode = ShipCode;
            DescriptionType _ShipCodeDesc = ShipCodeDesc;
            Flag _ShipPartial = ShipPartial;
            Flag _ShipEarly = ShipEarly;
            TermsCodeType _TermsCode = TermsCode;
            DescriptionType _TermsCodeDesc = TermsCodeDesc;
            SlsmanType _Slsman = Slsman;
            PriceCodeType _PriceCode = PriceCode;
            DescriptionType _PriceCodeDesc = PriceCodeDesc;
            TaxCodeType _TaxCode1 = TaxCode1;
            DescriptionType _TaxCode1Desc = TaxCode1Desc;
            TaxCodeType _TaxCode2 = TaxCode2;
            DescriptionType _TaxCode2Desc = TaxCode2Desc;
            TransNatType _TransNat = TransNat;
            TransNat2Type _TransNat2 = TransNat2;
            DeltermType _Delterm = Delterm;
            ProcessIndType _ProcessInd = ProcessInd;
            Flag _CreditHoldFlag = CreditHoldFlag;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCoCustomerValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldCustNum", _OldCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
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
                appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CorpCustName", _CorpCustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CorpCustContact", _CorpCustContact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CorpCustPhone", _CorpCustPhone, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CorpAddress", _CorpAddress, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipCodeDesc", _ShipCodeDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipPartial", _ShipPartial, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCodeDesc", _TermsCodeDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceCodeDesc", _PriceCodeDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHoldFlag", _CreditHoldFlag, ParameterDirection.InputOutput);
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
                CorpCust = _CorpCust;
                CorpCustName = _CorpCustName;
                CorpCustContact = _CorpCustContact;
                CorpCustPhone = _CorpCustPhone;
                CorpAddress = _CorpAddress;
                CurrCode = _CurrCode;
                UseExchRate = _UseExchRate;
                Whse = _Whse;
                ShipCode = _ShipCode;
                ShipCodeDesc = _ShipCodeDesc;
                ShipPartial = _ShipPartial;
                ShipEarly = _ShipEarly;
                TermsCode = _TermsCode;
                TermsCodeDesc = _TermsCodeDesc;
                Slsman = _Slsman;
                PriceCode = _PriceCode;
                PriceCodeDesc = _PriceCodeDesc;
                TaxCode1 = _TaxCode1;
                TaxCode1Desc = _TaxCode1Desc;
                TaxCode2 = _TaxCode2;
                TaxCode2Desc = _TaxCode2Desc;
                TransNat = _TransNat;
                TransNat2 = _TransNat2;
                Delterm = _Delterm;
                ProcessInd = _ProcessInd;
                CreditHoldFlag = _CreditHoldFlag;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
