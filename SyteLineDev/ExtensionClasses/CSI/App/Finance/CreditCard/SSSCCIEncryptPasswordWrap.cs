//PROJECT NAME: Finance
//CLASS NAME: SSSCCIEncryptPasswordWrap.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.CreditCard;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
    public class SSSCCIEncryptPasswordWrap : ISSSCCIEncryptPasswordWrap
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICreditCardUtil iCreditCardUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly ISQLValueComparerUtil sQLUtil;

        public SSSCCIEncryptPasswordWrap(IApplicationDB appDB,
        ICollectionInsertRequestFactory collectionInsertRequestFactory,
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        ICreditCardUtil iCreditCardUtil, 
        ISQLExpressionExecutor sQLExpressionExecutor,
        IScalarFunction scalarFunction,
        IExistsChecker existsChecker,
        ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.iCreditCardUtil = iCreditCardUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.sQLUtil = sQLUtil;
        }

        public (int? ReturnCode,
        string EncryptedPassword,
        string Infobar) SSSCCIEncryptPasswordWrapSp(string Password,
        string EncryptedPassword,
        string Infobar)
        {
            #region AltGen
            if (existsChecker.Exists(tableName: "optional_module",
            fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
            whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('SSSCCIEncryptPasswordWrapSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
            {
                //BEGIN
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute("DECLARE @ALTGEN TABLE ("
                + "    [SpName] SYSNAME);"
                + "SELECT * into #tv_ALTGEN from @ALTGEN ");
                StringType _ALTGEN_SpName = DBNull.Value;
                //string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;

                #region CRUD LoadToRecord
                var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                {"[SpName]",$"QUOTENAME('SSSCCIEncryptPasswordWrapSp' + CHAR(95) + [om].[ModuleName])"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('SSSCCIEncryptPasswordWrapSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord


                #region CRUD InsertByRecords
                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("")))
                {
                    //BEGIN

                    #region CRUD LoadToVariable
                    var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                    {_ALTGEN_SpName,$"[SpName]"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
                    tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(tv_ALTGEN1LoadRequest);
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_SSSCCIEncryptPasswordWrapSp(_ALTGEN_SpName,
                    Password,
                    EncryptedPassword,
                    Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;


                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, EncryptedPassword, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadColumn
                    var tv_ALTGEN2LoadRequestForDelete = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                    {
                        "SpName",
                    },
                    loadForChange: true,
                    lockingType: LockingType.None,
                    tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", _ALTGEN_SpName),
                    orderByClause: collectionLoadRequestFactory.Clause(""));

                    var tv_ALTGEN2LoadResponseForDelete = this.appDB.Load(tv_ALTGEN2LoadRequestForDelete);
                    #endregion  LoadColumn


                    #region CRUD DeleteByRecord
                    var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                    items: tv_ALTGEN2LoadResponseForDelete.Items);
                    this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                    #endregion DeleteByRecord

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                    //END

                }
                //END

            }
#endregion AltGen

            #region ExtGen
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSCCIEncryptPasswordWrapSp") != null)
            {
                var EXTGEN = AltExtGen_SSSCCIEncryptPasswordWrapSp("dbo.EXTGEN_SSSCCIEncryptPasswordWrapSp",
                Password,
                EncryptedPassword,
                Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.EncryptedPassword, EXTGEN.Infobar);
                }
            }

            int? Severity = null;
            Severity = 0;
            Infobar = null;

#endregion ExtGen

            if (!iCreditCardUtil.EncryptValue(Password, out EncryptedPassword, out Infobar))
            {
                Severity = 16;
            }

            return (Severity, EncryptedPassword, Infobar);
        }

        public (int? ReturnCode, string EncryptedPassword,
        string Infobar) AltExtGen_SSSCCIEncryptPasswordWrapSp(string AltExtGenSp,
        string Password,
        string EncryptedPassword,
        string Infobar)
        {
            PasswordType _Password = Password;
            PasswordType _EncryptedPassword = EncryptedPassword;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EncryptedPassword", _EncryptedPassword, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);




                EncryptedPassword = _EncryptedPassword;
                Infobar = _Infobar;

                return (Severity, EncryptedPassword, Infobar);
            }
        }
    }
}
