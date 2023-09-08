//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedColorCoding.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISSSFSSchedColorCoding
    {
        DataTable SSSFSSchedColorCodingSp(StringType iRefType);
    }

    public class SSSFSSchedColorCoding : ISSSFSSchedColorCoding
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSFSSchedColorCoding(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSFSSchedColorCodingSp(StringType iRefType)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSSFSSchedColorCodingSp";

                    appDB.AddCommandParameter(cmd, "iRefType", iRefType, ParameterDirection.Input);

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
