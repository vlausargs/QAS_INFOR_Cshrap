//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_GetContainerContent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAU_GetContainerContent
    {
        DataTable AU_GetContainerContentSp(ContainerNumType PContainerNum,
                                           ref Infobar Infobar);
    }

    public class AU_GetContainerContent : IAU_GetContainerContent
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public AU_GetContainerContent(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable AU_GetContainerContentSp(ContainerNumType PContainerNum,
                                                  ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_GetContainerContentSp";

                appDB.AddCommandParameter(cmd, "PContainerNum", PContainerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
