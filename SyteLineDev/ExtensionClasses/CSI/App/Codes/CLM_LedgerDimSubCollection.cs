//PROJECT NAME: CSICodes
//CLASS NAME: CLM_LedgerDimSubCollection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface ICLM_LedgerDimSubCollection
    {
        DataTable CLM_LedgerDimSubCollectionSp(DimensionObjectType ObjectName,
                                               RowPointerType TableRowPointer,
                                               DimensionNameType Dimension,
                                               LongListType FilterString);
    }

    public class CLM_LedgerDimSubCollection : ICLM_LedgerDimSubCollection
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_LedgerDimSubCollection(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_LedgerDimSubCollectionSp(DimensionObjectType ObjectName,
                                                      RowPointerType TableRowPointer,
                                                      DimensionNameType Dimension,
                                                      LongListType FilterString)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_LedgerDimSubCollectionSp";

                    appDB.AddCommandParameter(cmd, "ObjectName", ObjectName, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TableRowPointer", TableRowPointer, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Dimension", Dimension, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "FilterString", FilterString, ParameterDirection.Input);

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
