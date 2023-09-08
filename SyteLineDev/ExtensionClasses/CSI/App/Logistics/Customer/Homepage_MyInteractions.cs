//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyInteractions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_MyInteractions
    {
        DataTable Homepage_MyInteractionsSp(string UserName,
                                            string InteractionType,
                                            string Filter,
                                            string ParmsLanguageId);
    }

    public class Homepage_MyInteractions : IHomepage_MyInteractions
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_MyInteractions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_MyInteractionsSp(string UserName,
                                                   string InteractionType,
                                                   string Filter,
                                                   string ParmsLanguageId)
        {
            UsernameType _UserName = UserName;
            InteractionTypeType _InteractionType = InteractionType;
            LongListType _Filter = Filter;
            LanguageIDType _ParmsLanguageId = ParmsLanguageId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_MyInteractionsSp";

                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParmsLanguageId", _ParmsLanguageId, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
