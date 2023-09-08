//PROJECT NAME: CSICustomer
//CLASS NAME: GetArparmSiteGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGetArparmSiteGroup
    {
        int GetArparmSiteGroupSp(ref SiteGroupType PArparmSiteGroup);
    }

    public class GetArparmSiteGroup : IGetArparmSiteGroup
    {
        readonly IApplicationDB appDB;

        public GetArparmSiteGroup(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetArparmSiteGroupSp(ref SiteGroupType PArparmSiteGroup)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetArparmSiteGroupSp";

                appDB.AddCommandParameter(cmd, "PArparmSiteGroup", PArparmSiteGroup, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
