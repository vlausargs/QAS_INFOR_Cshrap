//PROJECT NAME: CSIMaterial
//CLASS NAME: GenerateFeatrank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGenerateFeatrank
    {
        int GenerateFeatrankSp(ItemType PItem,
                               OperNumType POperNum);
    }

    public class GenerateFeatrank : IGenerateFeatrank
    {
        readonly IApplicationDB appDB;

        public GenerateFeatrank(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GenerateFeatrankSp(ItemType PItem,
                                      OperNumType POperNum)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenerateFeatrankSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POperNum", POperNum, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
