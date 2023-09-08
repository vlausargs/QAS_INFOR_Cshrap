//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROStoreVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROStoreVars
    {
        int SSSFSSROStoreVarsSp(string Var1Name,
                                string Var1Value,
                                string Var2Name,
                                string Var2Value,
                                string Var3Name,
                                string Var3Value,
                                string Var4Name,
                                string Var4Value,
                                string Var5Name,
                                string Var5Value,
                                string Var6Name,
                                string Var6Value,
                                string Var7Name,
                                string Var7Value,
                                string Var8Name,
                                string Var8Value,
                                string Var9Name,
                                string Var9Value,
                                string Var10Name,
                                string Var10Value);
    }

    public class SSSFSSROStoreVars : ISSSFSSROStoreVars
    {
        readonly IApplicationDB appDB;

        public SSSFSSROStoreVars(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROStoreVarsSp(string Var1Name,
                                       string Var1Value,
                                       string Var2Name,
                                       string Var2Value,
                                       string Var3Name,
                                       string Var3Value,
                                       string Var4Name,
                                       string Var4Value,
                                       string Var5Name,
                                       string Var5Value,
                                       string Var6Name,
                                       string Var6Value,
                                       string Var7Name,
                                       string Var7Value,
                                       string Var8Name,
                                       string Var8Value,
                                       string Var9Name,
                                       string Var9Value,
                                       string Var10Name,
                                       string Var10Value)
        {
            StringType _Var1Name = Var1Name;
            LongListType _Var1Value = Var1Value;
            StringType _Var2Name = Var2Name;
            LongListType _Var2Value = Var2Value;
            StringType _Var3Name = Var3Name;
            LongListType _Var3Value = Var3Value;
            StringType _Var4Name = Var4Name;
            LongListType _Var4Value = Var4Value;
            StringType _Var5Name = Var5Name;
            LongListType _Var5Value = Var5Value;
            StringType _Var6Name = Var6Name;
            LongListType _Var6Value = Var6Value;
            StringType _Var7Name = Var7Name;
            LongListType _Var7Value = Var7Value;
            StringType _Var8Name = Var8Name;
            LongListType _Var8Value = Var8Value;
            StringType _Var9Name = Var9Name;
            LongListType _Var9Value = Var9Value;
            StringType _Var10Name = Var10Name;
            LongListType _Var10Value = Var10Value;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROStoreVarsSp";

                appDB.AddCommandParameter(cmd, "Var1Name", _Var1Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var1Value", _Var1Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var2Name", _Var2Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var2Value", _Var2Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var3Name", _Var3Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var3Value", _Var3Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var4Name", _Var4Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var4Value", _Var4Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var5Name", _Var5Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var5Value", _Var5Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var6Name", _Var6Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var6Value", _Var6Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var7Name", _Var7Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var7Value", _Var7Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var8Name", _Var8Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var8Value", _Var8Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var9Name", _Var9Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var9Value", _Var9Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var10Name", _Var10Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Var10Value", _Var10Value, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
