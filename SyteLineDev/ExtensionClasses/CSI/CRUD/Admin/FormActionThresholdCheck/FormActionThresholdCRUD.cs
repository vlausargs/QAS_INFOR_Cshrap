using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSI.CRUD.Admin.FormActionThresholdCheck
{
    public interface IFormActionThresholdCRUD
    {
        (IntType, IntType, ThresholdExpressionType, ObjectNameType) GetFormActionThreshold(FormNameType FormName, NameType FormAction);
        int? ExecuteThresholdExpression(ThresholdExpressionType ThresholdExpression, string[] FilterParm);
    }
    public class FormActionThresholdCRUD : IFormActionThresholdCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB appDB;

        public FormActionThresholdCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public int? ExecuteThresholdExpression(ThresholdExpressionType ThresholdExpression, string[] FilterParm)
        {
            int? rowCount = 0;
            using (var cmd = appDB.CreateCommand())
            {
                var dtReturn = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ThresholdExpression;
                if (ThresholdExpression.IsNull || ThresholdExpression == "")
                    return rowCount;

                int count = 1;
                foreach (StringType parm in FilterParm)
                {
                    appDB.AddCommandParameter(cmd, String.Format("P{0}", count), parm, ParameterDirection.Input);
                    count++;
                }

                dtReturn = appDB.ExecuteQuery(cmd);

                if (dtReturn.Rows.Count > 0)
                {
                    rowCount = (int)dtReturn.Rows[0].ItemArray[0];
                }
            }
            return rowCount;
        }
        public (IntType, IntType, ThresholdExpressionType, ObjectNameType) GetFormActionThreshold(FormNameType FormName, NameType FormAction)
        {
            IntType promptThreshold = DBNull.Value;
            IntType notificationThreshold = DBNull.Value;
            ThresholdExpressionType thresholdExpression = DBNull.Value;
            ObjectNameType promptMsgObj = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
               columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
               {
                   { promptThreshold,         "prompt_threshold" },
                   { notificationThreshold,   "notification_threshold"},
                   { thresholdExpression,     "threshold_expression" },
                   { promptMsgObj,            "prompt_msg_obj"}
               },

            tableName: "form_action_threshold",
            loadForChange: false,
            lockingType: LockingType.None,
            fromClause: collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"),
            orderByClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("threshold_enabled = 1 AND form_name = {0} AND form_action = {1}", FormName, FormAction)
            );
            //.AddIDOIntercept(
            //    idoName: "SLFormActionThresholds",
            //    idoWhereClause: string.Format("ThresholdEnabled = 1 AND FormName = {0} AND FormAction = {1}", appDB.FormatLiteral(FormName.Value), appDB.FormatLiteral(FormAction.Value)));

            appDB.Load(request);

            return (promptThreshold, notificationThreshold, thresholdExpression, promptMsgObj);
        }
    }
}
