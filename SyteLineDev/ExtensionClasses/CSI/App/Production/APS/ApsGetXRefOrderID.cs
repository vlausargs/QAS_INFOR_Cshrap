//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetXRefOrderID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetXRefOrderID
    {
        int ApsGetXRefOrderIDSp(JobTypeType SupplyRefType,
                                JobType SupplyRefNum,
                                SuffixType SupplyRefLineSuf,
                                CoReleaseType SupplyRefRelease,
                                JobTypeType DemandRefType,
                                JobType DemandRefNum,
                                SuffixType DemandRefLineSuf,
                                CoReleaseType DemandRefRelease,
                                JobmatlSequenceType DemandSequence,
                                ItemType Item,
                                ref ApsOrderType XRefOrderID);

        string ApsGetXRefOrderIDFn(
            string SupplyRefType,
            string SupplyRefNum,
            int? SupplyRefLineSuf,
            int? SupplyRefRelease,
            string DemandRefType,
            string DemandRefNum,
            int? DemandRefLineSuf,
            int? DemandRefRelease,
            int? DemandSequence,
            string Item);
    }

    public class ApsGetXRefOrderID : IApsGetXRefOrderID
    {
        readonly IApplicationDB appDB;

        public ApsGetXRefOrderID(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetXRefOrderIDSp(JobTypeType SupplyRefType,
                                       JobType SupplyRefNum,
                                       SuffixType SupplyRefLineSuf,
                                       CoReleaseType SupplyRefRelease,
                                       JobTypeType DemandRefType,
                                       JobType DemandRefNum,
                                       SuffixType DemandRefLineSuf,
                                       CoReleaseType DemandRefRelease,
                                       JobmatlSequenceType DemandSequence,
                                       ItemType Item,
                                       ref ApsOrderType XRefOrderID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetXRefOrderIDSp";

                appDB.AddCommandParameter(cmd, "SupplyRefType", SupplyRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefNum", SupplyRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefLineSuf", SupplyRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefRelease", SupplyRefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefType", DemandRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefNum", DemandRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefLineSuf", DemandRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefRelease", DemandRefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandSequence", DemandSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "XRefOrderID", XRefOrderID, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }

        public string ApsGetXRefOrderIDFn(
            string SupplyRefType,
            string SupplyRefNum,
            int? SupplyRefLineSuf,
            int? SupplyRefRelease,
            string DemandRefType,
            string DemandRefNum,
            int? DemandRefLineSuf,
            int? DemandRefRelease,
            int? DemandSequence,
            string Item)
        {
            JobTypeType _SupplyRefType = SupplyRefType;
            JobType _SupplyRefNum = SupplyRefNum;
            SuffixType _SupplyRefLineSuf = SupplyRefLineSuf;
            CoReleaseType _SupplyRefRelease = SupplyRefRelease;
            JobTypeType _DemandRefType = DemandRefType;
            JobType _DemandRefNum = DemandRefNum;
            SuffixType _DemandRefLineSuf = DemandRefLineSuf;
            CoReleaseType _DemandRefRelease = DemandRefRelease;
            JobmatlSequenceType _DemandSequence = DemandSequence;
            ItemType _Item = Item;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsGetXRefOrderID](@SupplyRefType, @SupplyRefNum, @SupplyRefLineSuf, @SupplyRefRelease, @DemandRefType, @DemandRefNum, @DemandRefLineSuf, @DemandRefRelease, @DemandSequence, @Item)";

                appDB.AddCommandParameter(cmd, "SupplyRefType", _SupplyRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefNum", _SupplyRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefLineSuf", _SupplyRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRefRelease", _SupplyRefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefType", _DemandRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefNum", _DemandRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefLineSuf", _DemandRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRefRelease", _DemandRefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandSequence", _DemandSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
