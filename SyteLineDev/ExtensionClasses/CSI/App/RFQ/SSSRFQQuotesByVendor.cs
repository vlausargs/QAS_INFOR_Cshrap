//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQQuotesByVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQQuotesByVendor
    {
        DataTable SSSRFQQuotesByVendorSp(string StartingVendNum,
                                         string EndingVendNum,
                                         string StartingRFQ,
                                         string EndingRFQ,
                                         string StartingProdCode,
                                         string EndingProdCode,
                                         string StartingItem,
                                         string EndingItem,
                                         string DistMethod,
                                         byte? IncludeSent);
    }

    public class SSSRFQQuotesByVendor : ISSSRFQQuotesByVendor
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRFQQuotesByVendor(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRFQQuotesByVendorSp(string StartingVendNum,
                                                string EndingVendNum,
                                                string StartingRFQ,
                                                string EndingRFQ,
                                                string StartingProdCode,
                                                string EndingProdCode,
                                                string StartingItem,
                                                string EndingItem,
                                                string DistMethod,
                                                byte? IncludeSent)
        {
            VendNumType _StartingVendNum = StartingVendNum;
            VendNumType _EndingVendNum = EndingVendNum;
            RFQNumType _StartingRFQ = StartingRFQ;
            RFQNumType _EndingRFQ = EndingRFQ;
            ProductCodeType _StartingProdCode = StartingProdCode;
            ProductCodeType _EndingProdCode = EndingProdCode;
            ItemType _StartingItem = StartingItem;
            ItemType _EndingItem = EndingItem;
            RFQDistMethodType _DistMethod = DistMethod;
            ListYesNoType _IncludeSent = IncludeSent;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQQuotesByVendorSp";

                appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingRFQ", _StartingRFQ, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingRFQ", _EndingRFQ, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingProdCode", _StartingProdCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingProdCode", _EndingProdCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DistMethod", _DistMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeSent", _IncludeSent, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
