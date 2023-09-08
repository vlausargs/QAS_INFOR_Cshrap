//PROJECT NAME: CSICustomer
//CLASS NAME: EDICustomerOrderValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEDICustomerOrderValid
    {
        int EDICustomerOrderValidSp(string CoNum,
                                    string OrderType,
                                    ref string CoTrxCode,
                                    ref string CustNum,
                                    ref DateTime? CoOrderDate,
                                    ref string CadCurrCode,
                                    ref string CadName,
                                    ref string CoPriceCode,
                                    ref string CoStat,
                                    ref DateTime? CoEffDate,
                                    ref DateTime? CoExpDate,
                                    ref DateTime? CoRecvDate,
                                    ref string CurrCstPrcFormat,
                                    ref byte? CadCreditHold,
                                    ref string Infobar);
    }

    public class EDICustomerOrderValid : IEDICustomerOrderValid
    {
        readonly IApplicationDB appDB;

        public EDICustomerOrderValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EDICustomerOrderValidSp(string CoNum,
                                           string OrderType,
                                           ref string CoTrxCode,
                                           ref string CustNum,
                                           ref DateTime? CoOrderDate,
                                           ref string CadCurrCode,
                                           ref string CadName,
                                           ref string CoPriceCode,
                                           ref string CoStat,
                                           ref DateTime? CoEffDate,
                                           ref DateTime? CoExpDate,
                                           ref DateTime? CoRecvDate,
                                           ref string CurrCstPrcFormat,
                                           ref byte? CadCreditHold,
                                           ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            EdiCoTypeType _OrderType = OrderType;
            EdiTrxCodeType _CoTrxCode = CoTrxCode;
            CustNumType _CustNum = CustNum;
            DateType _CoOrderDate = CoOrderDate;
            CurrCodeType _CadCurrCode = CadCurrCode;
            NameType _CadName = CadName;
            PriceCodeType _CoPriceCode = CoPriceCode;
            CoBlnStatusType _CoStat = CoStat;
            DateType _CoEffDate = CoEffDate;
            DateType _CoExpDate = CoExpDate;
            DateTimeType _CoRecvDate = CoRecvDate;
            InputMaskType _CurrCstPrcFormat = CurrCstPrcFormat;
            ListYesNoType _CadCreditHold = CadCreditHold;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EDICustomerOrderValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTrxCode", _CoTrxCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadCurrCode", _CadCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadName", _CadName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoPriceCode", _CoPriceCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoEffDate", _CoEffDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoExpDate", _CoExpDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoRecvDate", _CoRecvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCstPrcFormat", _CurrCstPrcFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadCreditHold", _CadCreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CoTrxCode = _CoTrxCode;
                CustNum = _CustNum;
                CoOrderDate = _CoOrderDate;
                CadCurrCode = _CadCurrCode;
                CadName = _CadName;
                CoPriceCode = _CoPriceCode;
                CoStat = _CoStat;
                CoEffDate = _CoEffDate;
                CoExpDate = _CoExpDate;
                CoRecvDate = _CoRecvDate;
                CurrCstPrcFormat = _CurrCstPrcFormat;
                CadCreditHold = _CadCreditHold;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
