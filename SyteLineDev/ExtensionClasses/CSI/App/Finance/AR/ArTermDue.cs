//PROJECT NAME: Data
//CLASS NAME: ArTermDue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Finance.AR
{
    public class ArTermDue : IArTermDue
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IDataTableUtil dataTableUtil;

        public ArTermDue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.dataTableUtil = dataTableUtil;
        }

        public ICollectionLoadResponse ArTermDueFn(
            string PSite_ref,
            string PCustNum,
            string PInvNum,
            int? PInvSeq,
            DateTime? CutoffDate)
        {
            SiteType _PSite_ref = PSite_ref;
            CustNumType _PCustNum = PCustNum;
            InvNumType _PInvNum = PInvNum;
            InvSeqType _PInvSeq = PInvSeq;
            DateType _CutoffDate = CutoffDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM dbo.[ArTermDue](@PSite_ref, @PCustNum, @PInvNum, @PInvSeq, @CutoffDate)";

                appDB.AddCommandParameter(cmd, "PSite_ref", _PSite_ref, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);
                dtReturn.TableName = "#fnt_ArTermDue";
                dataTableUtil.CloneDataTableIntoDB(dtReturn);

                return dataTableToCollectionLoadResponse.Process(dtReturn);
            }
        }
    }
}
