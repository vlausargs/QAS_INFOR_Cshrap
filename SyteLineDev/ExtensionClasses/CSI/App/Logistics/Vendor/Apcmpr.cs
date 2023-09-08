//PROJECT NAME: CSIVendor
//CLASS NAME: Apcmpr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IApcmpr
    {
        DataTable ApcmprSp(DateTime? ThruDate,
                           string BVendNum,
                           string EVendNum,
                           byte? PurgeNonAP,
                           byte? Commit);
    }

    public class Apcmpr : IApcmpr
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Apcmpr(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable ApcmprSp(DateTime? ThruDate,
                                  string BVendNum,
                                  string EVendNum,
                                  byte? PurgeNonAP,
                                  byte? Commit)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                DateType _ThruDate = ThruDate;
                VendNumType _BVendNum = BVendNum;
                VendNumType _EVendNum = EVendNum;
                ListYesNoType _PurgeNonAP = PurgeNonAP;
                ListYesNoType _Commit = Commit;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ApcmprSp";

                    appDB.AddCommandParameter(cmd, "ThruDate", _ThruDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "BVendNum", _BVendNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EVendNum", _EVendNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PurgeNonAP", _PurgeNonAP, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);

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
