//PROJECT NAME: CSIMaterial
//CLASS NAME: MO_JobScrapP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMO_JobScrapP
    {
        int MO_JobScrapPSp(RowPointerType SessionID,
                           JobType PItem,
                           JobType PJob,
                           SuffixType PJobSuffix,
                           QtyUnitType PQty,
                           UMType PUM,
                           WhseType PWhse,
                           LocType PLoc,
                           DateType PTransDate,
                           ReasonCodeType PReason,
                           LotType PLot,
                           AcctType PAccount,
                           UnitCode1Type PUnitCodes1,
                           UnitCode2Type PUnitCodes2,
                           UnitCode3Type PUnitCodes3,
                           UnitCode4Type PUnitCodes4,
                           EmpNumType PEmployee,
                           OperNumType POperNum,
                           WcType Pwc,
                           ShiftType PShift,
                           ref InfobarType Infobar);
    }

    public class MO_JobScrapP : IMO_JobScrapP
    {
        readonly IApplicationDB appDB;

        public MO_JobScrapP(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MO_JobScrapPSp(RowPointerType SessionID,
                                  JobType PItem,
                                  JobType PJob,
                                  SuffixType PJobSuffix,
                                  QtyUnitType PQty,
                                  UMType PUM,
                                  WhseType PWhse,
                                  LocType PLoc,
                                  DateType PTransDate,
                                  ReasonCodeType PReason,
                                  LotType PLot,
                                  AcctType PAccount,
                                  UnitCode1Type PUnitCodes1,
                                  UnitCode2Type PUnitCodes2,
                                  UnitCode3Type PUnitCodes3,
                                  UnitCode4Type PUnitCodes4,
                                  EmpNumType PEmployee,
                                  OperNumType POperNum,
                                  WcType Pwc,
                                  ShiftType PShift,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MO_JobScrapPSp";

                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobSuffix", PJobSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PQty", PQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUM", PUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PLoc", PLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTransDate", PTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PReason", PReason, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PLot", PLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAccount", PAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUnitCodes1", PUnitCodes1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUnitCodes2", PUnitCodes2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUnitCodes3", PUnitCodes3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUnitCodes4", PUnitCodes4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEmployee", PEmployee, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POperNum", POperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Pwc", Pwc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShift", PShift, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
