//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRtnLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXRtnLoad
    {
        DataTable SSSRMXRtnLoadSp(string VendNum,
                                  byte? Reverse,
                                  string FilterString);
    }

    public class SSSRMXRtnLoad : ISSSRMXRtnLoad
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRMXRtnLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRMXRtnLoadSp(string VendNum,
                                         byte? Reverse,
                                         string FilterString)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                VendNumType _VendNum = VendNum;
                ListYesNoType _Reverse = Reverse;
                LongListType _FilterString = FilterString;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSSRMXRtnLoadSp";

                    appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Reverse", _Reverse, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
