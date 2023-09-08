//PROJECT NAME: Employee
//CLASS NAME: AlertPORequisition.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Material;

namespace CSI.Employee
{
    public class AlertPORequisition : IAlertPORequisition
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IInsertEventInputParameter iInsertEventInputParameter;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
        readonly IResetSessionID iResetSessionID;
        readonly IScalarFunction scalarFunction;
        readonly IInterpretText iInterpretText;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISessionID iSessionID;
        readonly IFireEvent iFireEvent;
        readonly ISQLValueComparerUtil sQLUtil;

        public AlertPORequisition(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IInsertEventInputParameter iInsertEventInputParameter,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IResetSessionID iResetSessionID,
            IScalarFunction scalarFunction,
            IInterpretText iInterpretText,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISessionID iSessionID,
            IFireEvent iFireEvent,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iInsertEventInputParameter = iInsertEventInputParameter;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.iResetSessionID = iResetSessionID;
            this.scalarFunction = scalarFunction;
            this.iInterpretText = iInterpretText;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.iSessionID = iSessionID;
            this.iFireEvent = iFireEvent;
            this.sQLUtil = sQLUtil;
        }

        public (
            int? ReturnCode,
            string Inforbar)
        AlertPORequisitionSp(
            string RequestType,
            string EmpNum,
            string SupEmpNum,
            string RequesterName,
            string ApproverName,
            string ReqNum,
            int? ReqLine,
            string ReqCode,
            string ReqCodeDescription,
            string Item,
            string ItemDescription,
            string Inforbar)
        {
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            SiteType _Site = DBNull.Value;
            string Site = null;
            UsernameType _EmpUserName = DBNull.Value;
            string EmpUserName = null;
            EmailType _EmpEmail = DBNull.Value;
            string EmpEmail = null;
            EmpNumType _SupNum = DBNull.Value;
            string SupNum = null;
            UsernameType _SupUserName = DBNull.Value;
            string SupUserName = null;
            EmailType _SupEmail = DBNull.Value;
            string SupEmail = null;
            EmpNameType _EmpName = DBNull.Value;
            string EmpName = null;
            EmpNameType _SupName = DBNull.Value;
            string SupName = null;
            Guid? SaveSessionID = null;
            string Subject = null;
            string MsgBody = null;
            string MsgBody1 = null;
            string MsgHeader1 = null;
            string MsgHeader2 = null;
            string MsgHeader3 = null;
            string MsgHeader4 = null;
            string NewLine = null;
            string Tab = null;
            string Spaces13 = null;
            string ReqCodeLabel = null;
            string PORequisitionLabel = null;
            string LineLabel = null;
            string ItemLabel = null;
            string ConstructedText = null;
            Guid? SessionID = null;
            Guid? EventTrxID = null;
            Guid? EventParmID = null;
            string result = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AlertPORequisitionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
                        [SpName] SYSNAME);
                    SELECT * into #tv_ALTGEN from @ALTGEN ");

                #region CRUD LoadToRecord
                var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SpName","CAST (NULL AS NVARCHAR)"},
                        {"u0","[om].[ModuleName]"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AlertPORequisitionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("AlertPORequisitionSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("")))
                {
                    #region CRUD LoadToVariable
                    var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_ALTGEN_SpName,"[SpName]"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                    if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                    {
                        ALTGEN_SpName = _ALTGEN_SpName;
                    }
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_AlertPORequisitionSp(_ALTGEN_SpName,
                        RequestType,
                        EmpNum,
                        SupEmpNum,
                        RequesterName,
                        ApproverName,
                        ReqNum,
                        ReqLine,
                        ReqCode,
                        ReqCodeDescription,
                        Item,
                        ItemDescription,
                        Inforbar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, Inforbar);
                    }

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"[SpName]","[SpName]"},
                        },
                        tableName: "#tv_ALTGEN", 
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                    items: tv_ALTGEN2LoadResponse.Items);
                    this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                    #endregion DeleteByRecord

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                }
            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_AlertPORequisitionSp") != null)
            {
                var EXTGEN = AltExtGen_AlertPORequisitionSp("dbo.EXTGEN_AlertPORequisitionSp",
                    RequestType,
                    EmpNum,
                    SupEmpNum,
                    RequesterName,
                    ApproverName,
                    ReqNum,
                    ReqLine,
                    ReqCode,
                    ReqCodeDescription,
                    Item,
                    ItemDescription,
                    Inforbar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Inforbar);
                }
            }

            Severity = 0;
            NewLine = convertToUtil.ToString(stringUtil.Concat(stringUtil.Char(13), stringUtil.Char(10)));
            Tab = convertToUtil.ToString(stringUtil.Char(9));
            Spaces13 = convertToUtil.ToString(stringUtil.Char(13));
            EmpNum = this.iExpandKyByType.ExpandKyByTypeFn(
                "EmpNumType",
                EmpNum);
            Subject = "";
            MsgBody = "";
            MsgBody1 = "";
            MsgHeader1 = "";
            MsgHeader2 = "";
            MsgHeader3 = "";
            MsgHeader4 = "";

            #region CRUD LoadToVariable
            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Site,"site"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
            {
                Site = _Site;
            }
            #endregion  LoadToVariable

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText = this.iInterpretText.InterpretTextSp(
                Text: "FORMAT(sRequisitionCode)",
                InterpretedText: ReqCodeLabel,
                Infobar: Inforbar);
            ReqCodeLabel = InterpretText.InterpretedText;
            Inforbar = InterpretText.Infobar;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText1 = this.iInterpretText.InterpretTextSp(
                Text: "FORMAT(sPORequisition)",
                InterpretedText: PORequisitionLabel,
                Infobar: Inforbar);
            PORequisitionLabel = InterpretText1.InterpretedText;
            Inforbar = InterpretText1.Infobar;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText2 = this.iInterpretText.InterpretTextSp(
                Text: "FORMAT(sLine)",
                InterpretedText: LineLabel,
                Infobar: Inforbar);
            LineLabel = InterpretText2.InterpretedText;
            Inforbar = InterpretText2.Infobar;

            #endregion ExecuteMethodCall


            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText3 = this.iInterpretText.InterpretTextSp(
                Text: "FORMAT(sItem)",
                InterpretedText: ItemLabel,
                Infobar: Inforbar);
            ItemLabel = InterpretText3.InterpretedText;
            Inforbar = InterpretText3.Infobar;

            #endregion ExecuteMethodCall

            #region CRUD LoadToVariable
            var employeeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_EmpEmail,"email_addr"},
                    {_EmpUserName,"username"},
                    {_EmpName,"dbo.GetEmployeeName(emp_num)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "employee",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("emp_num = {0}", EmpNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var employeeLoadResponse = this.appDB.Load(employeeLoadRequest);
            if (employeeLoadResponse.Items.Count > 0)
            {
                EmpEmail = _EmpEmail;
                EmpUserName = _EmpUserName;
                EmpName = _EmpName;
            }
            #endregion  LoadToVariable

            if (EmpEmail == null || sQLUtil.SQLEqual(EmpEmail, "") == true)
            {

                #region CRUD LoadToVariable
                var UserEmailLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_EmpEmail,"EmailAddress"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "UserEmail",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("Username = {0} AND EmailType = 'P'", EmpUserName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var UserEmailLoadResponse = this.appDB.Load(UserEmailLoadRequest);
                if (UserEmailLoadResponse.Items.Count > 0)
                {
                    EmpEmail = _EmpEmail;
                }
                #endregion  LoadToVariable
            }

            #region CRUD LoadToVariable
            var employeeASeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SupNum,"posd.super_num"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "employee AS e",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED) INNER JOIN emp_pos AS ep WITH (READUNCOMMITTED) ON ep.emp_num = e.emp_num LEFT OUTER JOIN pos_det AS posd WITH (READUNCOMMITTED) ON posd.job_id = ep.job_id "
                + "AND ep.job_detail = posd.job_detail LEFT OUTER JOIN position AS pos WITH (READUNCOMMITTED) ON pos.job_id = posd.job_id"),
                whereClause: collectionLoadRequestFactory.Clause("ep.emp_num = {0}", EmpNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var employeeASeLoadResponse = this.appDB.Load(employeeASeLoadRequest);
            if (employeeASeLoadResponse.Items.Count > 0)
            {
                SupNum = _SupNum;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var employeeASe1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SupUserName,"e.username"},
                    {_SupEmail,"email_addr"},
                    {_SupName,"dbo.GetEmployeeName(emp_num)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "employee AS e",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("e.emp_num = {0}", SupNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var employeeASe1LoadResponse = this.appDB.Load(employeeASe1LoadRequest);
            if (employeeASe1LoadResponse.Items.Count > 0)
            {
                SupUserName = _SupUserName;
                SupEmail = _SupEmail;
                SupName = _SupName;
            }
            #endregion  LoadToVariable

            if (SupEmail == null || sQLUtil.SQLEqual(SupEmail, "") == true)
            {

                #region CRUD LoadToVariable
                var UserEmail1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SupEmail,"EmailAddress"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "UserEmail",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("Username = {0} AND EmailType = 'P'", SupUserName),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var UserEmail1LoadResponse = this.appDB.Load(UserEmail1LoadRequest);
                if (UserEmail1LoadResponse.Items.Count > 0)
                {
                    SupEmail = _SupEmail;
                }
                #endregion  LoadToVariable


            }
            MsgBody = stringUtil.Concat("<html>", "<table border=0 cellspacing=10>", "<tr>", "<th align=left>", stringUtil.IsNull(
                ReqCodeLabel,
                ""), "</th>", "<th align=left>", stringUtil.IsNull(
                PORequisitionLabel,
                ""), "</th>", "<th align=left>", stringUtil.IsNull(
                LineLabel,
                ""), "</th>", "<th align=left>", stringUtil.IsNull(
                ItemLabel,
                ""), "</th>", "</tr>", "<tr>", "<td>", stringUtil.IsNull(
                ReqCode,
                "   "), "</td>", "<td>", stringUtil.IsNull(
                ReqNum,
                "          "), "</td>", "<td>", Convert.ToString(ReqLine), "</td>", "<td>", stringUtil.IsNull(
                Item,
                ""), "</td>", "</tr>", "<tr>", "<td>", stringUtil.IsNull(
                ReqCodeDescription,
                " "), "</td>", "<td>", " ", "</td>", "<td>", " ", "</td>", "<td>", stringUtil.IsNull(
                ItemDescription,
                " "), "</td>", "</tr>", "</table>", "</html>");
            if (MsgBody != null && sQLUtil.SQLNotEqual(MsgBody, "") == true)
            {
                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InterpretTextSp
                var InterpretText4 = this.iInterpretText.InterpretTextSp(
                    Text: "FORMAT(sPORequisitionRequest)",
                    InterpretedText: Subject,
                    Infobar: Inforbar);
                Severity = InterpretText4.ReturnCode;
                Subject = InterpretText4.InterpretedText;
                Inforbar = InterpretText4.Infobar;

                #endregion ExecuteMethodCall

                Subject = stringUtil.Concat(Subject, " - ", stringUtil.IsNull(
                    stringUtil.Upper(EmpName),
                    ""));
                SessionID = this.iSessionID.SessionIDSp();
                EventTrxID = Guid.NewGuid();
                EventParmID = Guid.NewGuid();
                SaveSessionID = this.iSessionID.SessionIDSp();
            }
            if (sQLUtil.SQLEqual(RequestType, "R") == true)
            {
                ConstructedText = stringUtil.Concat("FORMAT(mPORequisitionRequestHeader1, ", stringUtil.IsNull(
                    EmpName,
                    ""), ")");

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InterpretTextSp
                var InterpretText5 = this.iInterpretText.InterpretTextSp(
                    Text: ConstructedText,
                    InterpretedText: MsgHeader1,
                    Infobar: Inforbar);
                Severity = InterpretText5.ReturnCode;
                MsgHeader1 = InterpretText5.InterpretedText;
                Inforbar = InterpretText5.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InterpretTextSp
                var InterpretText6 = this.iInterpretText.InterpretTextSp(
                    Text: "FORMAT(mTimeOffRequestHeader2)",
                    InterpretedText: MsgHeader2,
                    Infobar: Inforbar);
                Severity = InterpretText6.ReturnCode;
                MsgHeader2 = InterpretText6.InterpretedText;
                Inforbar = InterpretText6.Infobar;

                #endregion ExecuteMethodCall

                MsgBody1 = stringUtil.Concat("<html>", "<table border=0>", "<tr>", "<td>", MsgHeader1, "</td>", "</tr>", "<tr>", "<td>", MsgHeader2, "</td>", "</tr>", "<tr>", "<td>", " ", "</td>", "</tr>", "</table>", "</html>", MsgBody);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter1 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: EmpEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter1;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter2 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter2;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter3 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter3;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent.ReturnCode;
                Inforbar = FireEvent.Infobar;

                #endregion ExecuteMethodCall

                EventTrxID = Guid.NewGuid();
                EventParmID = Guid.NewGuid();

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter4 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter4;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter5 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: SupEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter5;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter6 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter6;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter7 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter7;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent1 = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent1.ReturnCode;
                Inforbar = FireEvent1.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ResetSessionIDSp
                var ResetSessionID = this.iResetSessionID.ResetSessionIDSp(ID: SaveSessionID);

                #endregion ExecuteMethodCall
            }
            if (sQLUtil.SQLEqual(RequestType, "A") == true)
            {
                ConstructedText = stringUtil.Concat("FORMAT(mPORequisitionRequestHeader3, ", stringUtil.IsNull(
                    SupName,
                    ""), ")");

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InterpretTextSp
                var InterpretText7 = this.iInterpretText.InterpretTextSp(
                    Text: ConstructedText,
                    InterpretedText: MsgHeader3,
                    Infobar: Inforbar);
                Severity = InterpretText7.ReturnCode;
                MsgHeader3 = InterpretText7.InterpretedText;
                Inforbar = InterpretText7.Infobar;

                #endregion ExecuteMethodCall

                MsgBody1 = stringUtil.Concat("<html>", "<table border=0>", "<tr>", "<td>", MsgHeader3, "</td>", "</tr>", "<tr>", "<td>", " ", "</td>", "</tr>", "</table>", "</html>", MsgBody);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter8 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter8;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter9 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: EmpEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter9;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter10 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter10;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter11 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter11;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent2 = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent2.ReturnCode;
                Inforbar = FireEvent2.Infobar;

                #endregion ExecuteMethodCall

                EventTrxID = Guid.NewGuid();
                EventParmID = Guid.NewGuid();

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter12 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter12;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter13 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: SupEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter13;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter14 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter14;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter15 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter15;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent3 = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent3.ReturnCode;
                Inforbar = FireEvent3.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ResetSessionIDSp
                var ResetSessionID1 = this.iResetSessionID.ResetSessionIDSp(ID: SaveSessionID);

                #endregion ExecuteMethodCall
            }
            if (sQLUtil.SQLEqual(RequestType, "J") == true)
            {
                ConstructedText = stringUtil.Concat("FORMAT(mPORequisitionRequestHeader4, ", stringUtil.IsNull(
                    SupName,
                    ""), ")");

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InterpretTextSp
                var InterpretText8 = this.iInterpretText.InterpretTextSp(
                    Text: ConstructedText,
                    InterpretedText: MsgHeader4,
                    Infobar: Inforbar);
                Severity = InterpretText8.ReturnCode;
                MsgHeader4 = InterpretText8.InterpretedText;
                Inforbar = InterpretText8.Infobar;

                #endregion ExecuteMethodCall

                MsgBody1 = stringUtil.Concat("<html>", "<table border=0>", "<tr>", "<td>", MsgHeader4, "</td>", "</tr>", "<tr>", "<td>", " ", "</td>", "</tr>", "</table>", "</html>", MsgBody);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter16 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter16;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter17 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: EmpEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter17;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter18 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter18;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter19 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter19;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent4 = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent4.ReturnCode;
                Inforbar = FireEvent4.Infobar;

                #endregion ExecuteMethodCall

                EventTrxID = Guid.NewGuid();
                EventParmID = Guid.NewGuid();

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter20 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailHTMLFormat",
                    Value: "TRUE",
                    IsOutput: 0);
                Severity = InsertEventInputParameter20;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter21 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailTo",
                    Value: SupEmail,
                    IsOutput: 0);
                Severity = InsertEventInputParameter21;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter22 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailSubject",
                    Value: Subject,
                    IsOutput: 0);
                Severity = InsertEventInputParameter22;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: InsertEventInputParameterSp
                var InsertEventInputParameter23 = this.iInsertEventInputParameter.InsertEventInputParameterSp(
                    EventParmId: EventParmID,
                    Name: "EmailMessage",
                    Value: MsgBody1,
                    IsOutput: 0);
                Severity = InsertEventInputParameter23;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: FireEventSp
                var FireEvent5 = this.iFireEvent.FireEventSp(
                    eventName: "GenericSendEmail",
                    configName: null,
                    initiator: null,
                    sessionID: SessionID,
                    eventTrxId: null,
                    eventParmId: EventParmID,
                    transactional: false,
                    generatingEventActionStateRowPointer: null,
                    anyHandlersFailed: false,
                    result: result,
                    Infobar: Inforbar,
                    site: Site);
                Severity = FireEvent5.ReturnCode;
                Inforbar = FireEvent5.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ResetSessionIDSp
                var ResetSessionID2 = this.iResetSessionID.ResetSessionIDSp(ID: SaveSessionID);

                #endregion ExecuteMethodCall
            }

            return (Severity, Inforbar);
        }

        public (int? ReturnCode,
            string Inforbar)
        AltExtGen_AlertPORequisitionSp(
            string AltExtGenSp,
            string RequestType,
            string EmpNum,
            string SupEmpNum,
            string RequesterName,
            string ApproverName,
            string ReqNum,
            int? ReqLine,
            string ReqCode,
            string ReqCodeDescription,
            string Item,
            string ItemDescription,
            string Inforbar)
        {
            StringType _RequestType = RequestType;
            EmpNumType _EmpNum = EmpNum;
            EmpNumType _SupEmpNum = SupEmpNum;
            EmpNameType _RequesterName = RequesterName;
            EmpNameType _ApproverName = ApproverName;
            ReqNumType _ReqNum = ReqNum;
            ReqLineType _ReqLine = ReqLine;
            ReqCodeType _ReqCode = ReqCode;
            DescriptionType _ReqCodeDescription = ReqCodeDescription;
            ItemType _Item = Item;
            DescriptionType _ItemDescription = ItemDescription;
            InfobarType _Inforbar = Inforbar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "RequestType", _RequestType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupEmpNum", _SupEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RequesterName", _RequesterName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ApproverName", _ApproverName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReqLine", _ReqLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReqCode", _ReqCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReqCodeDescription", _ReqCodeDescription, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Inforbar", _Inforbar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Inforbar = _Inforbar;

                return (Severity, Inforbar);
            }
        }
    }
}
