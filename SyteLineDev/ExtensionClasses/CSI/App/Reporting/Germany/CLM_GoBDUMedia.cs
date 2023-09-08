//PROJECT NAME: CSIDELOC
//CLASS NAME: CLM_GoBDUMedia.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Reporting.Germany
{
    public interface ICLM_GoBDUMedia
    {
        DataTable CLM_GoBDUMediaSp(NameType MediaName,
                                   DateType TransDateBeg,
                                   DateType TransDateEnd,
                                   LongListType CollectionsList);
    }

    public class CLM_GoBDUMedia : ICLM_GoBDUMedia
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;

        public CLM_GoBDUMedia(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_GoBDUMediaSp(NameType MediaName,
                                          DateType TransDateBeg,
                                          DateType TransDateEnd,
                                          LongListType CollectionsList)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_GoBDUMediaSp";

                    appDB.AddCommandParameter(cmd, "MediaName", MediaName, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TransDateBeg", TransDateBeg, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TransDateEnd", TransDateEnd, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "CollectionsList", CollectionsList, ParameterDirection.Input);

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
