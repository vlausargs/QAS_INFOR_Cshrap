//PROJECT NAME: CSIFinance
//CLASS NAME: IsFixAssetExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IIsFixAssetExist
    {
        int IsFixAssetExistSp(FaNumType FaNum,
                              ref ListYesNoType IsExist,
                              ref FaClassType FaClass,
                              ref DeptType FaDept,
                              ref InfobarType Infobar);
    }

    public class IsFixAssetExist : IIsFixAssetExist
    {
        readonly IApplicationDB appDB;

        public IsFixAssetExist(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int IsFixAssetExistSp(FaNumType FaNum,
                                     ref ListYesNoType IsExist,
                                     ref FaClassType FaClass,
                                     ref DeptType FaDept,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IsFixAssetExistSp";

                appDB.AddCommandParameter(cmd, "FaNum", FaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsExist", IsExist, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FaClass", FaClass, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FaDept", FaDept, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}