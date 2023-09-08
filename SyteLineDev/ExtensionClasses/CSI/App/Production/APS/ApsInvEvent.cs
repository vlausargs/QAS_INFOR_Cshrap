using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Production.APS
{
    public class ApsInvEvent : IApsInvEvent
    {

        readonly IApplicationDB appDB;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IDataTableUtil dataTableUtil;

        public ApsInvEvent(IApplicationDB appDB, 
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            IDataTableUtil dataTableUtil)
        {
            this.appDB = appDB;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.dataTableUtil = dataTableUtil;
        }

        public ICollectionLoadResponse ApsInvEventFn(int? detailDisplay, int? useFullyTransactedOrders, int? calledForIntraSiteTransfer)
        {
            Flag _detailDisplay = detailDisplay;
            ListYesNoType _useFullyTransactedOrders = useFullyTransactedOrders;
            ListYesNoType _calledForIntraSiteTransfer = calledForIntraSiteTransfer;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.[ApsInvEvent](@detailDisplay, @useFullyTransactedOrders, @calledForIntraSiteTransfer);";

                appDB.AddCommandParameter(cmd, "detailDisplay", _detailDisplay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "useFullyTransactedOrders", _useFullyTransactedOrders, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "calledForIntraSiteTransfer", _calledForIntraSiteTransfer, ParameterDirection.Input);

                DataTable dtReturn = appDB.ExecuteQuery(cmd);
                dtReturn.TableName = "#fnt_ApsInvEvent";
                this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

                return dataTableToCollectionLoadResponse.Process(dtReturn);
            }

        }
    }
}
