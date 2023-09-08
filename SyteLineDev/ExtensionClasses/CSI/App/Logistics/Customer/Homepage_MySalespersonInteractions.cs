//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MySalespersonInteractions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_MySalespersonInteractions
    {
        DataTable Homepage_MySalespersonInteractionsSp(string UserName,
                                                       string Filter,
                                                       string ParmsLanguageId);
    }

    public class Homepage_MySalespersonInteractions : IHomepage_MySalespersonInteractions
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_MySalespersonInteractions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_MySalespersonInteractionsSp(string UserName,
                                                              string Filter,
                                                              string ParmsLanguageId)
        {
            UsernameType _UserName = UserName;
            LongListType _Filter = Filter;
            LanguageIDType _ParmsLanguageId = ParmsLanguageId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_MySalespersonInteractionsSp";

                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParmsLanguageId", _ParmsLanguageId, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
