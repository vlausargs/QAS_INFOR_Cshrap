//PROJECT NAME: Production
//CLASS NAME: ValidateExpRecDemand.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Material;

namespace CSI.Production.APS
{
    public class ValidateExpRecDemand : IValidateExpRecDemand
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;

        public ValidateExpRecDemand(IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (int? ReturnCode, string Infobar) ValidateExpRecDemandSp(string DemandType, string DemandNum, string Infobar)
        {
            int? Severity = null;
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateExpRecDemandSp") != null)
            {
                var EXTGEN = AltExtGen_ValidateExpRecDemandSp("dbo.EXTGEN_ValidateExpRecDemandSp",
                    DemandType,
                    DemandNum,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Infobar);
                }
            }

            Severity = 0;
            if (sQLUtil.SQLBool(sQLUtil.SQLNotEqual(DemandNum, "")))
            {
                //BEGIN
                if (sQLUtil.SQLBool(sQLUtil.SQLEqual(DemandType, "J")))
                {
                    //BEGIN
                    DemandNum = this.iExpandKyByType.ExpandKyByTypeFn("JobType", DemandNum);
                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                        tableName: "job",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("job.job = {0}", DemandNum)))))
                    {
                        //BEGIN
                        Infobar = null;

                        #region CRUD ExecuteMethodCall

                        var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
                            , BaseMsg: "E=Invalid"
                            , Parm1: "@job.job");

                        Severity = MsgApp.ReturnCode;
                        Infobar = MsgApp.Infobar;
                        #endregion ExecuteMethodCall

                        //END
                    }
                    //END
                }
                else
                {
                    //BEGIN
                    DemandNum = this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", DemandNum);
                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                        tableName: "coitem",
                        fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN co ON coitem.co_num = co.co_num"),
                        whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {0} AND coitem.stat NOT IN ('C') AND co.stat NOT IN ('C', 'H')", DemandNum)))))
                    {
                        //BEGIN
                        Infobar = null;

                        #region CRUD ExecuteMethodCall

                        var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                            , BaseMsg: "E=Invalid"
                            , Parm1: "@coitem.co_num");

                        Severity = MsgApp1.ReturnCode;
                        Infobar = MsgApp1.Infobar;
                        #endregion ExecuteMethodCall

                        //END
                    }
                    //END
                }
                //END

            }
            return (Severity, Infobar);

        }
        public (int? ReturnCode, string Infobar) AltExtGen_ValidateExpRecDemandSp(string AltExtGenSp,
            string DemandType,
            string DemandNum,
            string Infobar)
        {
            StringType _DemandType = DemandType;
            StringType _DemandNum = DemandNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandNum", _DemandNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
