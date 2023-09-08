using CSI.Data.SQL.UDDT;
using System;
using CSI.MG;
using CSI.CRUD.Admin.FormActionThresholdCheck;
using CSI.MG.MGCore;

namespace CSI.Admin.FormActionThresholdCheck
{
    public interface IFormActionThresholdCheck
    {
        int CheckThreshold(string FormName,
                           string FormAction,
                           string FilterParmsValue,
                           string Site,
                           string ConfigurationName,
                           ref int? RecordCount,
                           ref string PromptMsgObj,
                           ref string PromptMsg,
                           ref string NotificationMsg,
                           ref byte? IsExceedPromptThreshold,
                           ref byte? IsExceedNotificationThreshold);
    }

    public class FormActionThresholdCheck : IFormActionThresholdCheck
    {
        readonly IMessageProvider messageProvider;
        readonly IFormActionThresholdCRUD formActionThresholdCRUD;
        readonly IUserName userName;

        public FormActionThresholdCheck(
            IMessageProvider MessageProvider, 
            IFormActionThresholdCRUD FormActionThresholdCRUD, 
            IUserName userName)
        {
            this.messageProvider = MessageProvider ?? throw new ArgumentNullException(nameof(MessageProvider));
            this.formActionThresholdCRUD = FormActionThresholdCRUD ?? throw new ArgumentNullException(nameof(FormActionThresholdCRUD));
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public int CheckThreshold(string FormName,
                                  string FormAction,
                                  string FilterParmsValue,
                                  string Site,
                                  string ConfigurationName,
                                  ref int? RecordCount,
                                  ref string PromptMsgObj,
                                  ref string PromptMsg,
                                  ref string NotificationMsg,
                                  ref byte? IsExceedPromptThreshold,
                                  ref byte? IsExceedNotificationThreshold)
        {
            IntType promptThreshold = 0;
            IntType notificationThreshold = 0;
            ThresholdExpressionType thresholdExpression = DBNull.Value;
            ObjectNameType promptMsgObj = DBNull.Value;
            string[] filterParm;

            (promptThreshold, notificationThreshold, thresholdExpression, promptMsgObj) = formActionThresholdCRUD.GetFormActionThreshold(FormName, FormAction);
            
            PromptMsgObj = promptMsgObj;
            IsExceedPromptThreshold = 0;
            IsExceedNotificationThreshold = 0;

            filterParm = ConvertToParmArray(FilterParmsValue);
            RecordCount = formActionThresholdCRUD.ExecuteThresholdExpression(thresholdExpression, filterParm);
            if (RecordCount >= notificationThreshold && notificationThreshold != 0)
            {
                IsExceedNotificationThreshold = 1;
                NotificationMsg = messageProvider.GetMessage("W=ProcessLargeVolumeData", this.userName.GetUserName(), RecordCount, FormName,FormAction, Site, ConfigurationName);
            }

            if(RecordCount >= promptThreshold && promptThreshold != 0)
            {
                IsExceedPromptThreshold = 1;
                PromptMsg = messageProvider.GetMessage("Q=ProcessLargeVolumeDataContinueNoYes", RecordCount, PromptMsgObj);
            }
            return 0;

        }
        private string[] ConvertToParmArray(string FilterParmsValue)
        {
            string filterParmsValue = "";
            if (FilterParmsValue != null)
            {
               filterParmsValue = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(FilterParmsValue));
            }

            string[] filterParm = filterParmsValue.Split('\t');
            return filterParm;
        }
    }
}
