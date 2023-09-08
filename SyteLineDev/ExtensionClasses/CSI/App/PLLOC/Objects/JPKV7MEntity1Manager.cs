using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace PLLOC.Objects
{
    public class JPKV7MEntity1Manager: IJPKV7MEntity1Manager
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly string SiteRef;

        public JPKV7MEntity1Manager(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        string SiteRef)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.SiteRef = SiteRef;
        }

        public (string email, string name, string phone) GetJPKV7MEntity1ValueFromDB()
        {
            StringType _company = DBNull.Value;
            StringType _email = DBNull.Value;
            StringType _phone = DBNull.Value;

            #region CRUD LoadToVariable
            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
            {
            {_company,$"company"},
            {_email,$"email_addr"},
            {_phone,$"phone"},
            },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "parms_mst",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", this.SiteRef),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(parmsLoadRequest);

            #endregion  LoadToVariable

            return (_email.Value, _company.Value, _phone.Value);
        }
    }
}
