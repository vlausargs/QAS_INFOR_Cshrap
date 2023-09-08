//PROJECT NAME: CSIMaterial
//CLASS NAME: WarningReceiveItemToContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IWarningReceiveItemToContainer
    {
        int WarningReceiveItemToContainerSp(ContainerNumType ContainerNum,
                                            ref InfobarType PromptMsg,
                                            ref InfobarType PromptButtons);
    }

    public class WarningReceiveItemToContainer : IWarningReceiveItemToContainer
    {
        readonly IApplicationDB appDB;

        public WarningReceiveItemToContainer(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WarningReceiveItemToContainerSp(ContainerNumType ContainerNum,
                                                   ref InfobarType PromptMsg,
                                                   ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WarningReceiveItemToContainerSp";

                appDB.AddCommandParameter(cmd, "ContainerNum", ContainerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
