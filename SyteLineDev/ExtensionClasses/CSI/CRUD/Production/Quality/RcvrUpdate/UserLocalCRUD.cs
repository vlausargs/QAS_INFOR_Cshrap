using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.Quality.RcvrUpdate
{
    public interface IUserLocalCRUD
    {
        void GetUserLocal(out UserCodeType UserCode);
    }
    public class UserLocalCRUD : IUserLocalCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly IApplicationDB appDB;

        public UserLocalCRUD(ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory, ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadStatementRequestFactory));
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public void GetUserLocal(out UserCodeType UserCode)
        {
            UserCodeType userCode = DBNull.Value;

            var request = collectionLoadStatementRequestFactory.SQLLoad(
               columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
               {
                            { userCode,         "user_code" }
               },
               selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList FROM user_local join usernames on usernames.userid = user_local.userid WHERE usernames.username = dbo.UserNameSp()"));

            appDB.Load(request);

            UserCode = userCode;
;
        }
    }
}
