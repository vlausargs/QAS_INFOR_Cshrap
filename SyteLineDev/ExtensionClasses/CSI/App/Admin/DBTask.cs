//PROJECT NAME: CSIAdmin
//CLASS NAME: DBTask.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IDBTask
    {
        int PerformTaskById(string AppTaskId, string SpName, string DBName, ref string Infobar);
    }
    public class DBTask : IDBTask
    {
        readonly IApplicationDB appDB;
        readonly IMGInvoker mgInvoker;
        readonly bool isCloud;

        public DBTask(IApplicationDB appDB, IMGInvoker mgInvoker, bool isCloud)
        {
            this.appDB = appDB;
            this.mgInvoker = mgInvoker;
            this.isCloud = isCloud;
        }

        public int PerformTaskById(string AppTaskId, string SpName, string DBName, ref string Infobar)
        {
            int returnValue = 0;
            IMGInvokeResponseData response;

            if (this.isCloud == true)
            {
                switch (AppTaskId)
                {
                    case "PurgeNextKeys":
                        response = this.mgInvoker.Invoke("NextKeyDefinitions", "PurgeNextKeysSp");
                        return returnValue;
                    case "DropTempTables":
                        response = this.mgInvoker.Invoke("SP!", "DropTempTablesSp");
                        return returnValue;
                    case "DisallowPageLocks":
                        response = this.mgInvoker.Invoke("SP!", "DisallowPageLocksSp");
                        return returnValue;
                    default:
                        response = this.mgInvoker.Invoke("ApplicationMessages", "MsgAppSp", Infobar, "E=NoExist0", AppTaskId, "",
                      "", "", "", "", "", "", "", "", "", "", "", "", "");
                        if (response != null && response.Parameters != null)
                            Infobar = response.Parameters[0].Value.ToString();
                        return 16;
                }
            }
            else
            {
                switch (AppTaskId)
                {
                    case "PurgeNextKeys":
                        response = this.mgInvoker.Invoke("NextKeyDefinitions", "PurgeNextKeysSp");
                        return returnValue;
                    case "DropTempTables":
                        response = this.mgInvoker.Invoke("SP!", "DropTempTablesSp");
                        return returnValue;
                    case "DisallowPageLocks":
                        response = this.mgInvoker.Invoke("SP!", "DisallowPageLocksSp");
                        return returnValue;
                    case "UpdateStatistics":
                        response = this.mgInvoker.Invoke("SP!", "UpdateStatisticsSp");
                        return returnValue;
                    case "ShrinkDatabase":
                        response = this.mgInvoker.Invoke("SLNonTrans", "ShrinkDatabaseSp");
                        return returnValue;
                    case "RebuildIndexes":
                        response = this.mgInvoker.Invoke("SP!", "RebuildIndexesSp");
                        return returnValue;
                    case "RecompileStoredProcedure":
                        response = this.mgInvoker.Invoke("SP!", "RecompileStoredProcedureSp", SpName, DBName);
                        return returnValue;
                    default:
                        response = this.mgInvoker.Invoke("ApplicationMessages", "MsgAppSp", Infobar, "E=NoExist0", AppTaskId, "",
                      "", "", "", "", "", "", "", "", "", "", "", "", "");
                        if (response != null && response.Parameters != null)
                            Infobar = response.Parameters[0].Value.ToString();
                        return 16;
                }
            }
        }
    }
}