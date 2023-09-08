//PROJECT NAME: Material
//CLASS NAME: ItemInvPurg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemInvPurg
    {
        (ICollectionLoadResponse Data, int? ReturnCode, int? PhyInvCount, string Infobar) ItemInvPurgSp(string SelectedWhse,
                                                                                                        byte? RunMode,
                                                                                                        int? PhyInvCount,
                                                                                                        string Infobar,
                                                                                                        byte? NotCountedNotPrinted);
    }

    public class ItemInvPurg : IItemInvPurg
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public ItemInvPurg(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, int? PhyInvCount, string Infobar) ItemInvPurgSp(string SelectedWhse,
                                                                                                               byte? RunMode,
                                                                                                               int? PhyInvCount,
                                                                                                               string Infobar,
                                                                                                               byte? NotCountedNotPrinted)
        {
            WhseType _SelectedWhse = SelectedWhse;
            FlagNyType _RunMode = RunMode;
            IntType _PhyInvCount = PhyInvCount;
            InfobarType _Infobar = Infobar;
            ListYesNoType _NotCountedNotPrinted = NotCountedNotPrinted;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemInvPurgSp";

                appDB.AddCommandParameter(cmd, "SelectedWhse", _SelectedWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PhyInvCount", _PhyInvCount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NotCountedNotPrinted", _NotCountedNotPrinted, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                PhyInvCount = _PhyInvCount;
                Infobar = _Infobar;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, PhyInvCount, Infobar);
            }
        }
    }
}
