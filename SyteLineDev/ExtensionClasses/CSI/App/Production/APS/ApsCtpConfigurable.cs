//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpConfigurable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpConfigurable
    {
        int ApsCtpConfigurableSp(ItemType PItem,
                                 ref ListYesNoType PConfigurable);
    }

    public class ApsCtpConfigurable : IApsCtpConfigurable
    {
        readonly IApplicationDB appDB;

        public ApsCtpConfigurable(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpConfigurableSp(ItemType PItem,
                                        ref ListYesNoType PConfigurable)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpConfigurableSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PConfigurable", PConfigurable, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
