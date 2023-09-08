//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductGetRefInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICoProductGetRefInfo
    {
        int CoProductGetRefInfoSp(RefTypeIKOTType OrderType,
                                  CoProjTrnNumType OrderNum,
                                  CoProjTaskTrnLineType OrderLine,
                                  CoReleaseType OrderRelease,
                                  ref CoNumType CustNum,
                                  ref NameType CustName,
                                  ref QtyUnitType QtyOrdered,
                                  ref DateType OrderDate,
                                  ref DateType DueDate,
                                  ref InfobarType Infobar);
    }

    public class CoProductGetRefInfo : ICoProductGetRefInfo
    {
        readonly IApplicationDB appDB;

        public CoProductGetRefInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoProductGetRefInfoSp(RefTypeIKOTType OrderType,
                                         CoProjTrnNumType OrderNum,
                                         CoProjTaskTrnLineType OrderLine,
                                         CoReleaseType OrderRelease,
                                         ref CoNumType CustNum,
                                         ref NameType CustName,
                                         ref QtyUnitType QtyOrdered,
                                         ref DateType OrderDate,
                                         ref DateType DueDate,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoProductGetRefInfoSp";

                appDB.AddCommandParameter(cmd, "OrderType", OrderType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderNum", OrderNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderLine", OrderLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderRelease", OrderRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustName", CustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOrdered", QtyOrdered, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrderDate", OrderDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
