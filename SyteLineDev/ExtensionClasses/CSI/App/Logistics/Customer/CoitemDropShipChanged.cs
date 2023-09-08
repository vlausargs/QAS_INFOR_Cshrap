//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemDropShipChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoitemDropShipChanged
    {
        int CoitemDropShipChangedSp(CoNumType CoNum,
                                    CoLineType CoLine,
                                    ItemType Item,
                                    DropShipNoType CustNum,
                                    DropSeqType CustSeq,
                                    TaxCodeType CoTaxCode1,
                                    TaxCodeType CoTaxCode2,
                                    TaxCodeType TaxCode1,
                                    TaxCodeType TaxCode2,
                                    ref LongAddress ShipToAddress,
                                    ref LongListType ECCode,
                                    ref TaxCodeType OutTaxCode1,
                                    ref TaxCodeType OutTaxCode2,
                                    ref InfobarType PromptMsg,
                                    ref InfobarType PromptButtons);
    }

    public class CoitemDropShipChanged : ICoitemDropShipChanged
    {
        readonly IApplicationDB appDB;

        public CoitemDropShipChanged(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoitemDropShipChangedSp(CoNumType CoNum,
                                           CoLineType CoLine,
                                           ItemType Item,
                                           DropShipNoType CustNum,
                                           DropSeqType CustSeq,
                                           TaxCodeType CoTaxCode1,
                                           TaxCodeType CoTaxCode2,
                                           TaxCodeType TaxCode1,
                                           TaxCodeType TaxCode2,
                                           ref LongAddress ShipToAddress,
                                           ref LongListType ECCode,
                                           ref TaxCodeType OutTaxCode1,
                                           ref TaxCodeType OutTaxCode2,
                                           ref InfobarType PromptMsg,
                                           ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoitemDropShipChangedSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTaxCode1", CoTaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTaxCode2", CoTaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode1", TaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode2", TaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipToAddress", ShipToAddress, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ECCode", ECCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutTaxCode1", OutTaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutTaxCode2", OutTaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
