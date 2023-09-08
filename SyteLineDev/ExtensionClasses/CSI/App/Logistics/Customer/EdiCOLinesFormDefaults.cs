//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCOLinesFormDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCOLinesFormDefaults
    {
        int EdiCOLinesFormDefaultsSp(string CoNum,
                                     ref string Stat,
                                     ref decimal? QtyOrderedConv,
                                     ref DateTime? DueDate,
                                     ref decimal? Price,
                                     ref decimal? PriceConv,
                                     ref string CustNum,
                                     ref int? CustSeq,
                                     ref string Whse,
                                     ref string Pricecode,
                                     ref string PricecodeDesc,
                                     ref string RefType,
                                     ref string TaxCode1,
                                     ref string TaxCode1Desc,
                                     ref string TaxCode2,
                                     ref string TaxCode2Desc,
                                     ref string CurrCode,
                                     ref string CurrAmtFormat,
                                     ref string CurrCstPrcFormat,
                                     ref string Infobar);
    }

    public class EdiCOLinesFormDefaults : IEdiCOLinesFormDefaults
    {
        readonly IApplicationDB appDB;

        public EdiCOLinesFormDefaults(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCOLinesFormDefaultsSp(string CoNum,
                                            ref string Stat,
                                            ref decimal? QtyOrderedConv,
                                            ref DateTime? DueDate,
                                            ref decimal? Price,
                                            ref decimal? PriceConv,
                                            ref string CustNum,
                                            ref int? CustSeq,
                                            ref string Whse,
                                            ref string Pricecode,
                                            ref string PricecodeDesc,
                                            ref string RefType,
                                            ref string TaxCode1,
                                            ref string TaxCode1Desc,
                                            ref string TaxCode2,
                                            ref string TaxCode2Desc,
                                            ref string CurrCode,
                                            ref string CurrAmtFormat,
                                            ref string CurrCstPrcFormat,
                                            ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            CoitemStatusType _Stat = Stat;
            QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
            DateType _DueDate = DueDate;
            CostPrcType _Price = Price;
            CostPrcType _PriceConv = PriceConv;
            CustNumType _CustNum = CustNum;
            CustSeqType _CustSeq = CustSeq;
            WhseType _Whse = Whse;
            PriceCodeType _Pricecode = Pricecode;
            DescriptionType _PricecodeDesc = PricecodeDesc;
            RefTypeIJKPRTType _RefType = RefType;
            TaxCodeType _TaxCode1 = TaxCode1;
            DescriptionType _TaxCode1Desc = TaxCode1Desc;
            TaxCodeType _TaxCode2 = TaxCode2;
            DescriptionType _TaxCode2Desc = TaxCode2Desc;
            CurrCodeType _CurrCode = CurrCode;
            InputMaskType _CurrAmtFormat = CurrAmtFormat;
            InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCOLinesFormDefaultsSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PricecodeDesc", _PricecodeDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Stat = _Stat;
                QtyOrderedConv = _QtyOrderedConv;
                DueDate = _DueDate;
                Price = _Price;
                PriceConv = _PriceConv;
                CustNum = _CustNum;
                CustSeq = _CustSeq;
                Whse = _Whse;
                Pricecode = _Pricecode;
                PricecodeDesc = _PricecodeDesc;
                RefType = _RefType;
                TaxCode1 = _TaxCode1;
                TaxCode1Desc = _TaxCode1Desc;
                TaxCode2 = _TaxCode2;
                TaxCode2Desc = _TaxCode2Desc;
                CurrCode = _CurrCode;
                CurrAmtFormat = _CurrAmtFormat;
                CurrCstPrcFormat = _CurrCstPrcFormat;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
