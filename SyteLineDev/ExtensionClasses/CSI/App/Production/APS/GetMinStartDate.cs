//PROJECT NAME: Production
//CLASS NAME: GetMinStartDate.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
    public class GetMinStartDate : IGetMinStartDate
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public GetMinStartDate(IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            int? ReturnCode,
            DateTime? StartDate)
        GetMinStartDateSp(
            DateTime? StartDate)
        {
            GenericDateType _StartDate = StartDate;
            int? Severity = 0;

            GenericDateType _NewDate = DBNull.Value;
            DateTime? NewDate = null;
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetMinStartDateSp") != null)
            {
                var EXTGEN = AltExtGen_GetMinStartDateSp("dbo.EXTGEN_GetMinStartDateSp",
                StartDate);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.StartDate);
                }
            }

            #region CRUD LoadToVariable
            var ALTSCHEDLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_StartDate,"STARTDATE"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "ALTSCHED",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (NOLOCK)"),
                whereClause: collectionLoadRequestFactory.Clause($"ALTNO = 0"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var ALTSCHEDLoadResponse = this.appDB.Load(ALTSCHEDLoadRequest);
            if (ALTSCHEDLoadResponse.Items.Count > 0)
            {
                StartDate = _StartDate;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var RESSCHD000LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_NewDate,"MIN(STARTDATE)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "RESSCHD000",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var RESSCHD000LoadResponse = this.appDB.Load(RESSCHD000LoadRequest);

            if (RESSCHD000LoadResponse.Items.Count > 0)
            {
                NewDate = _NewDate;
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLLessThan(NewDate, StartDate) == true)
            {
                StartDate = convertToUtil.ToDateTime(NewDate);
            }

            return (Severity, StartDate);
        }

        public (int? ReturnCode,
            DateTime? StartDate)
        AltExtGen_GetMinStartDateSp(
            string AltExtGenSp,
            DateTime? StartDate)
        {
            GenericDateType _StartDate = StartDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                StartDate = _StartDate;

                return (Severity, StartDate);
            }
        }
    }
}
