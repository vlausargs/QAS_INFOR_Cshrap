using CSI.MG;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.Logistics.Customer
{
    public interface ITmpPickList
    {
        bool CheckTmpPickListExisted(RowPointerType ProcessID, CoNumType CoNum, CoLineType CoLine, CoReleaseType CoRelease);
    }

    public class TmpPickList : ITmpPickList
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public TmpPickList(IApplicationDB applicationDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = applicationDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public bool CheckTmpPickListExisted(RowPointerType ProcessID, CoNumType CoNum, CoLineType CoLine, CoReleaseType CoRelease)
        {
            bool retVal = true;

            using (var cmd = appDB.CreateCommand())
            {
                var dtReturn = new DataTable();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT 1 FROM tmp_pick_list WHERE process_id = @ProcessID AND ref_num = @CoNum and ref_line_suf = @CoLIne and ref_release = @CoRelease";
                appDB.AddCommandParameter(cmd, "ProcessID", ProcessID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLIne", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                if (dtReturn.Rows.Count > 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }

            return retVal;
        }
    }
}
