//PROJECT NAME: CSIFinance
//CLASS NAME: MobileMaxMenuItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMobileMaxMenuItems
    {
        int MobileMaxMenuItemsSp(FormNameType MobileHomepage,
                                 ref IntType MaxMenuItems);
    }

    public class MobileMaxMenuItems : IMobileMaxMenuItems
    {
        readonly IApplicationDB appDB;

        public MobileMaxMenuItems(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MobileMaxMenuItemsSp(FormNameType MobileHomepage,
                                        ref IntType MaxMenuItems)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MobileMaxMenuItemsSp";

                appDB.AddCommandParameter(cmd, "MobileHomepage", MobileHomepage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MaxMenuItems", MaxMenuItems, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
