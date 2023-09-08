//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSContractValidCust
    {
        (int? ReturnCode, int? CustSeq,
        string BillToAddr,
        string ShipToAddr,
        string ShipToName,
        string ShipToAddr1,
        string ShipToAddr2,
        string ShipToAddr3,
        string ShipToAddr4,
        string ShipToCity,
        string ShipToState,
        string ShipToZip,
        string ShipToCounty,
        string ShipToCountry,
        string EndUserType,
        string TermsCode,
        string TermsCodeDesc,
        string Slsman,
        string CurrCode,
        byte? FixedEuro,
        byte? CreditHold,
        string TaxCode1,
        string TaxCode1Desc,
        string TaxCode2,
        string TaxCode2Desc,
        string Infobar,
        string CurAmtFormat,
        string CurCstPrcFormat,
        string PriorCode,
        string ShipToStateCode,
        string ShipToStateDesc) SSSFSContractValidCustSp(string CustNum,
        int? CustSeq,
        string Level,
        string BillToAddr,
        string ShipToAddr,
        string ShipToName,
        string ShipToAddr1,
        string ShipToAddr2,
        string ShipToAddr3,
        string ShipToAddr4,
        string ShipToCity,
        string ShipToState,
        string ShipToZip,
        string ShipToCounty,
        string ShipToCountry,
        string EndUserType,
        string TermsCode,
        string TermsCodeDesc,
        string Slsman,
        string CurrCode,
        byte? FixedEuro,
        byte? CreditHold,
        string TaxCode1,
        string TaxCode1Desc,
        string TaxCode2,
        string TaxCode2Desc,
        string Infobar,
        string CurAmtFormat,
        string CurCstPrcFormat,
        string PriorCode = null,
        string ShipToStateCode = null,
        string ShipToStateDesc = null);
    }

    public class SSSFSContractValidCust : ISSSFSContractValidCust
    {
        readonly IApplicationDB appDB;

        public SSSFSContractValidCust(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, int? CustSeq,
        string BillToAddr,
        string ShipToAddr,
        string ShipToName,
        string ShipToAddr1,
        string ShipToAddr2,
        string ShipToAddr3,
        string ShipToAddr4,
        string ShipToCity,
        string ShipToState,
        string ShipToZip,
        string ShipToCounty,
        string ShipToCountry,
        string EndUserType,
        string TermsCode,
        string TermsCodeDesc,
        string Slsman,
        string CurrCode,
        byte? FixedEuro,
        byte? CreditHold,
        string TaxCode1,
        string TaxCode1Desc,
        string TaxCode2,
        string TaxCode2Desc,
        string Infobar,
        string CurAmtFormat,
        string CurCstPrcFormat,
        string PriorCode,
        string ShipToStateCode,
        string ShipToStateDesc) SSSFSContractValidCustSp(string CustNum,
        int? CustSeq,
        string Level,
        string BillToAddr,
        string ShipToAddr,
        string ShipToName,
        string ShipToAddr1,
        string ShipToAddr2,
        string ShipToAddr3,
        string ShipToAddr4,
        string ShipToCity,
        string ShipToState,
        string ShipToZip,
        string ShipToCounty,
        string ShipToCountry,
        string EndUserType,
        string TermsCode,
        string TermsCodeDesc,
        string Slsman,
        string CurrCode,
        byte? FixedEuro,
        byte? CreditHold,
        string TaxCode1,
        string TaxCode1Desc,
        string TaxCode2,
        string TaxCode2Desc,
        string Infobar,
        string CurAmtFormat,
        string CurCstPrcFormat,
        string PriorCode = null,
        string ShipToStateCode = null,
        string ShipToStateDesc = null)
        {
            CustNumType _CustNum = CustNum;
            CustSeqType _CustSeq = CustSeq;
            StringType _Level = Level;
            LongAddress _BillToAddr = BillToAddr;
            LongAddress _ShipToAddr = ShipToAddr;
            NameType _ShipToName = ShipToName;
            AddressType _ShipToAddr1 = ShipToAddr1;
            AddressType _ShipToAddr2 = ShipToAddr2;
            AddressType _ShipToAddr3 = ShipToAddr3;
            AddressType _ShipToAddr4 = ShipToAddr4;
            CityType _ShipToCity = ShipToCity;
            StateType _ShipToState = ShipToState;
            PostalCodeType _ShipToZip = ShipToZip;
            CountyType _ShipToCounty = ShipToCounty;
            CountryType _ShipToCountry = ShipToCountry;
            EndUserTypeType _EndUserType = EndUserType;
            TermsCodeType _TermsCode = TermsCode;
            DescriptionType _TermsCodeDesc = TermsCodeDesc;
            SlsmanType _Slsman = Slsman;
            CurrCodeType _CurrCode = CurrCode;
            ListYesNoType _FixedEuro = FixedEuro;
            ListYesNoType _CreditHold = CreditHold;
            TaxCodeType _TaxCode1 = TaxCode1;
            DescriptionType _TaxCode1Desc = TaxCode1Desc;
            TaxCodeType _TaxCode2 = TaxCode2;
            DescriptionType _TaxCode2Desc = TaxCode2Desc;
            InfobarType _Infobar = Infobar;
            InputMaskType _CurAmtFormat = CurAmtFormat;
            InputMaskType _CurCstPrcFormat = CurCstPrcFormat;
            FSIncPriorCodeType _PriorCode = PriorCode;
            StateType _ShipToStateCode = ShipToStateCode;
            DescriptionType _ShipToStateDesc = ShipToStateDesc;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSContractValidCustSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BillToAddr", _BillToAddr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddr", _ShipToAddr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToName", _ShipToName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddr1", _ShipToAddr1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddr2", _ShipToAddr2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddr3", _ShipToAddr3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToAddr4", _ShipToAddr4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToCity", _ShipToCity, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToState", _ShipToState, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToZip", _ShipToZip, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToCounty", _ShipToCounty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToCountry", _ShipToCountry, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCodeDesc", _TermsCodeDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixedEuro", _FixedEuro, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurAmtFormat", _CurAmtFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurCstPrcFormat", _CurCstPrcFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToStateCode", _ShipToStateCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipToStateDesc", _ShipToStateDesc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CustSeq = _CustSeq;
                BillToAddr = _BillToAddr;
                ShipToAddr = _ShipToAddr;
                ShipToName = _ShipToName;
                ShipToAddr1 = _ShipToAddr1;
                ShipToAddr2 = _ShipToAddr2;
                ShipToAddr3 = _ShipToAddr3;
                ShipToAddr4 = _ShipToAddr4;
                ShipToCity = _ShipToCity;
                ShipToState = _ShipToState;
                ShipToZip = _ShipToZip;
                ShipToCounty = _ShipToCounty;
                ShipToCountry = _ShipToCountry;
                EndUserType = _EndUserType;
                TermsCode = _TermsCode;
                TermsCodeDesc = _TermsCodeDesc;
                Slsman = _Slsman;
                CurrCode = _CurrCode;
                FixedEuro = _FixedEuro;
                CreditHold = _CreditHold;
                TaxCode1 = _TaxCode1;
                TaxCode1Desc = _TaxCode1Desc;
                TaxCode2 = _TaxCode2;
                TaxCode2Desc = _TaxCode2Desc;
                Infobar = _Infobar;
                CurAmtFormat = _CurAmtFormat;
                CurCstPrcFormat = _CurCstPrcFormat;
                PriorCode = _PriorCode;
                ShipToStateCode = _ShipToStateCode;
                ShipToStateDesc = _ShipToStateDesc;

                return (Severity, CustSeq, BillToAddr, ShipToAddr, ShipToName, ShipToAddr1, ShipToAddr2, ShipToAddr3, ShipToAddr4, ShipToCity, ShipToState, ShipToZip, ShipToCounty, ShipToCountry, EndUserType, TermsCode, TermsCodeDesc, Slsman, CurrCode, FixedEuro, CreditHold, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, Infobar, CurAmtFormat, CurCstPrcFormat, PriorCode, ShipToStateCode, ShipToStateDesc);
            }
        }
    }
}
