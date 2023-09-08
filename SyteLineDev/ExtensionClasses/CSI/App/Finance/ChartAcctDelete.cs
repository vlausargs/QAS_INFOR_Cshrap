//PROJECT NAME: Finance
//CLASS NAME: ChartAcctDelete.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Finance
{
    public class ChartAcctDelete : IChartAcctDelete
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IChartAcctDeleteCRUD iChartAcctDeleteCRUD;

        public ChartAcctDelete(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IChartAcctDeleteCRUD iChartAcctDeleteCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iChartAcctDeleteCRUD = iChartAcctDeleteCRUD;
        }

        public (
            int? ReturnCode,
            string Infobar)
        ChartAcctDeleteSp(
            int? pNewRecord = 0,
            string pChartAcct = null,
            string Infobar = null)
        {

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            string ParmsSite = null;
            if (this.iChartAcctDeleteCRUD.Optional_ModuleForExists())
            {
                //BEGIN
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iChartAcctDeleteCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ChartAcctDeleteSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iChartAcctDeleteCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iChartAcctDeleteCRUD.Tv_ALTGENForExists())
                {
                    //BEGIN
                    var tv_ALTGEN1Load = this.iChartAcctDeleteCRUD.Tv_ALTGEN1Load();
                    ALTGEN_SpName = tv_ALTGEN1Load;
                    var ALTGEN = this.iChartAcctDeleteCRUD.AltExtGen_ChartAcctDeleteSp(ALTGEN_SpName,
                        pNewRecord,
                        pChartAcct,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iChartAcctDeleteCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iChartAcctDeleteCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                    //END

                }
                //END

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ChartAcctDeleteSp") != null)
            {
                var EXTGEN = this.iChartAcctDeleteCRUD.AltExtGen_ChartAcctDeleteSp("dbo.EXTGEN_ChartAcctDeleteSp",
                    pNewRecord,
                    pChartAcct,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Infobar);
                }
            }

            Severity = 0;
            Infobar = null;
            ParmsSite = null;
            if (sQLUtil.SQLEqual(pNewRecord, 1) == true)
            {
                //BEGIN
                return (Severity, Infobar);//END

            }
            if (this.iChartAcctDeleteCRUD.LedgerForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "ledger",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.JournalForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp1 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "journal",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp1.ReturnCode;
                Infobar = MsgApp1.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Ana_LedgerForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp2 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "ana_ledger",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp2.ReturnCode;
                Infobar = MsgApp2.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ApdrafttForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp3 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "apdraftt",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp3.ReturnCode;
                Infobar = MsgApp3.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ApparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp4 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "apparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp4.ReturnCode;
                Infobar = MsgApp4.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AppmtdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp5 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "appmtd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp5.ReturnCode;
                Infobar = MsgApp5.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AptrxForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp6 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "aptrx",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp6.ReturnCode;
                Infobar = MsgApp6.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AptrxdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp7 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "aptrxd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp7.ReturnCode;
                Infobar = MsgApp7.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AptrxpForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp8 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "aptrxp",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp8.ReturnCode;
                Infobar = MsgApp8.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AptrxrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp9 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "aptrxr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp9.ReturnCode;
                Infobar = MsgApp9.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.AptxrdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp10 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "aptxrd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp10.ReturnCode;
                Infobar = MsgApp10.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArdrafttForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp11 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "ardraftt",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp11.ReturnCode;
                Infobar = MsgApp11.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArfinForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp12 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "arfin",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp12.ReturnCode;
                Infobar = MsgApp12.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArinvForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp13 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "arinv",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp13.ReturnCode;
                Infobar = MsgApp13.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArinvdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp14 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "arinvd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp14.ReturnCode;
                Infobar = MsgApp14.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp15 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "arparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp15.ReturnCode;
                Infobar = MsgApp15.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArpmtdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp16 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "arpmtd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp16.ReturnCode;
                Infobar = MsgApp16.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ArtranForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp17 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "artran",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp17.ReturnCode;
                Infobar = MsgApp17.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Bank_AddrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp18 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "bank_addr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp18.ReturnCode;
                Infobar = MsgApp18.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Bank_HdrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp19 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "bank_hdr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp19.ReturnCode;
                Infobar = MsgApp19.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Chart_BpForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp20 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "chart_bp",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp20.ReturnCode;
                Infobar = MsgApp20.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Chart_DForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp21 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "chart_d",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp21.ReturnCode;
                Infobar = MsgApp21.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.CommdueForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp22 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "commdue",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp22.ReturnCode;
                Infobar = MsgApp22.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.CommtranForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp23 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "commtran",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp23.ReturnCode;
                Infobar = MsgApp23.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.CurracctForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp24 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "curracct",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp24.ReturnCode;
                Infobar = MsgApp24.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.CurrparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp25 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "currparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp25.ReturnCode;
                Infobar = MsgApp25.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.DcjmForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp26 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "dcjm",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp26.ReturnCode;
                Infobar = MsgApp26.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.DeptForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp27 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "dept",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp27.ReturnCode;
                Infobar = MsgApp27.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.DiscountForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp28 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "discount",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp28.ReturnCode;
                Infobar = MsgApp28.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.DistacctForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp29 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "distacct",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp29.ReturnCode;
                Infobar = MsgApp29.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Edi_Inv_HdrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp30 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "edi_inv_hdr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp30.ReturnCode;
                Infobar = MsgApp30.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Edi_Inv_ItemForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp31 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "edi_inv_item",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp31.ReturnCode;
                Infobar = MsgApp31.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Edi_Inv_StaxForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp32 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "edi_inv_stax",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp32.ReturnCode;
                Infobar = MsgApp32.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.EmployeeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp33 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "employee",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp33.ReturnCode;
                Infobar = MsgApp33.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.EndtypeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp34 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "endtype",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp34.ReturnCode;
                Infobar = MsgApp34.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.FaclassForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp35 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "faclass",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp35.ReturnCode;
                Infobar = MsgApp35.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.FadistForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp36 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "fadist",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp36.ReturnCode;
                Infobar = MsgApp36.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.FaparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp37 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "faparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp37.ReturnCode;
                Infobar = MsgApp37.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.IndcodeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp38 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "indcode",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp38.ReturnCode;
                Infobar = MsgApp38.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Inv_HdrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp39 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "inv_hdr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp39.ReturnCode;
                Infobar = MsgApp39.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Inv_ItemForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp40 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "inv_item",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp40.ReturnCode;
                Infobar = MsgApp40.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Inv_StaxForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp41 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "inv_stax",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp41.ReturnCode;
                Infobar = MsgApp41.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ItemlifoForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp42 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "itemlifo",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp42.ReturnCode;
                Infobar = MsgApp42.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ItemlocForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp43 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "itemloc",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp43.ReturnCode;
                Infobar = MsgApp43.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.JobForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp44 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "job",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp44.ReturnCode;
                Infobar = MsgApp44.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ParmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp45 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "parms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp45.ReturnCode;
                Infobar = MsgApp45.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PitemhForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp46 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "pitemh",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp46.ReturnCode;
                Infobar = MsgApp46.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Po_BlnForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp47 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "po_bln",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp47.ReturnCode;
                Infobar = MsgApp47.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PoblnhForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp48 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "poblnh",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp48.ReturnCode;
                Infobar = MsgApp48.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PoitemForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp49 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "poitem",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp49.ReturnCode;
                Infobar = MsgApp49.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PoparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp50 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "poparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp50.ReturnCode;
                Infobar = MsgApp50.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PrbankForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp51 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prbank",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp51.ReturnCode;
                Infobar = MsgApp51.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PrdecdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp52 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prdecd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp52.ReturnCode;
                Infobar = MsgApp52.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PreqitemForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp53 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "preqitem",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp53.ReturnCode;
                Infobar = MsgApp53.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ProdcodeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp54 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prodcode",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp54.ReturnCode;
                Infobar = MsgApp54.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ProdvarForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp55 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prodvar",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp55.ReturnCode;
                Infobar = MsgApp55.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Proj_WipForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp56 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "proj_wip",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp56.ReturnCode;
                Infobar = MsgApp56.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ProjparmForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp57 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "projparm",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp57.ReturnCode;
                Infobar = MsgApp57.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PrparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp58 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp58.ReturnCode;
                Infobar = MsgApp58.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PrtaxtForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp59 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prtaxt",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp59.ReturnCode;
                Infobar = MsgApp59.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.PrtrxdForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp60 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "prtrxd",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp60.ReturnCode;
                Infobar = MsgApp60.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.ReasonForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp61 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "reason",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp61.ReturnCode;
                Infobar = MsgApp61.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Reason1ForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp62 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "reason",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp62.ReturnCode;
                Infobar = MsgApp62.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.RmaparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp63 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "rmaparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp63.ReturnCode;
                Infobar = MsgApp63.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.SfcparmsForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp64 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "sfcparms",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp64.ReturnCode;
                Infobar = MsgApp64.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            var parms1Load = this.iChartAcctDeleteCRUD.Parms1Load();
            ParmsSite = parms1Load;
            if (this.iChartAcctDeleteCRUD.SitenetForExists(pChartAcct, ParmsSite))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp65 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "sitenet",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp65.ReturnCode;
                Infobar = MsgApp65.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.TaxcodeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp66 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "taxcode",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp66.ReturnCode;
                Infobar = MsgApp66.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Vch_DistForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp67 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vch_dist",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp67.ReturnCode;
                Infobar = MsgApp67.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Vch_HdrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp68 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vch_hdr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp68.ReturnCode;
                Infobar = MsgApp68.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Vch_ItemForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp69 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vch_item",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp69.ReturnCode;
                Infobar = MsgApp69.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Vch_PrForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp70 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vch_pr",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp70.ReturnCode;
                Infobar = MsgApp70.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Vch_StaxForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp71 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vch_stax",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp71.ReturnCode;
                Infobar = MsgApp71.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.VendcatForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp72 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vendcat",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp72.ReturnCode;
                Infobar = MsgApp72.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.VendorForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp73 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "vendor",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp73.ReturnCode;
                Infobar = MsgApp73.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.WcForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp74 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "wc",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp74.ReturnCode;
                Infobar = MsgApp74.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (this.iChartAcctDeleteCRUD.Inv_Item_SurchargeForExists(pChartAcct))
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp75 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=ExistFor=",
                    Parm1: "inv_item_surcharge",
                    Parm2: "account",
                    Parm3: pChartAcct);
                Severity = MsgApp75.ReturnCode;
                Infobar = MsgApp75.Infobar;

                #endregion ExecuteMethodCall

                //END

            }
            if (Infobar != null)
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp76 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=CmdFailed1",
                    Parm1: "delete",
                    Parm2: "chart",
                    Parm3: "account",
                    Parm4: pChartAcct);
                Severity = MsgApp76.ReturnCode;
                Infobar = MsgApp76.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, Infobar);//END

            }
            return (Severity, Infobar);

        }

    }
}
