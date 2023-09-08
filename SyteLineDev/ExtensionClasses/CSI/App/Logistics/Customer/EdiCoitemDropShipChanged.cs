//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemDropShipChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCoitemDropShipChanged
    {
        int EdiCoitemDropShipChangedSp(string CoNum,
                                       short? CoLine,
                                       string Item,
                                       string CustNum,
                                       int? CustSeq,
                                       string CoTaxCode1,
                                       string CoTaxCode2,
                                       string TaxCode1,
                                       string TaxCode2,
                                       ref string ShipToAddress,
                                       ref string OutTaxCode1,
                                       ref string OutTaxCode2,
                                       ref string PromptMsg,
                                       ref string PromptButtons);
    }

    public class EdiCoitemDropShipChanged : IEdiCoitemDropShipChanged
    {
        readonly IApplicationDB appDB;

        public EdiCoitemDropShipChanged(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCoitemDropShipChangedSp(string CoNum,
                                              short? CoLine,
                                              string Item,
                                              string CustNum,
                                              int? CustSeq,
                                              string CoTaxCode1,
                                              string CoTaxCode2,
                                              string TaxCode1,
                                              string TaxCode2,
                                              ref string ShipToAddress,
                                              ref string OutTaxCode1,
                                              ref string OutTaxCode2,
                                              ref string PromptMsg,
                                              ref string PromptButtons)
        {
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            ItemType _Item = Item;
            DropShipNoType _CustNum = CustNum;
            DropSeqType _CustSeq = CustSeq;
            TaxCodeType _CoTaxCode1 = CoTaxCode1;
            TaxCodeType _CoTaxCode2 = CoTaxCode2;
            TaxCodeType _TaxCode1 = TaxCode1;
            TaxCodeType _TaxCode2 = TaxCode2;
            LongAddress _ShipToAddress = ShipToAddress;
            TaxCodeType _OutTaxCode1 = OutTaxCode1;
            TaxCodeType _OutTaxCode2 = OutTaxCode2;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCoitemDropShipChangedSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTaxCode1", _CoTaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTaxCode2", _CoTaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutTaxCode1", _OutTaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutTaxCode2", _OutTaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ShipToAddress = _ShipToAddress;
                OutTaxCode1 = _OutTaxCode1;
                OutTaxCode2 = _OutTaxCode2;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;

                return Severity;
            }
        }
    }
}
