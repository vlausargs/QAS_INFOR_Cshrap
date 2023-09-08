//PROJECT NAME: CSICodes
//CLASS NAME: LoadValueRes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface ILoadValueRes
    {
        int LoadValueResSp(DimensionValueType Attribute,
                           DimensionValueType Value,
                           DimensionValueType Val,
                           DimensionAttributeTypeType Parm_type,
                           ref DimensionValueType NewVal,
                           ref InfobarType InfoBar);
    }

    public class LoadValueRes : ILoadValueRes
    {
        readonly IApplicationDB appDB;

        public LoadValueRes(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int LoadValueResSp(DimensionValueType Attribute,
                                  DimensionValueType Value,
                                  DimensionValueType Val,
                                  DimensionAttributeTypeType Parm_type,
                                  ref DimensionValueType NewVal,
                                  ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoadValueResSp";

                appDB.AddCommandParameter(cmd, "Attribute", Attribute, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Value", Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Val", Val, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm_type", Parm_type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewVal", NewVal, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
