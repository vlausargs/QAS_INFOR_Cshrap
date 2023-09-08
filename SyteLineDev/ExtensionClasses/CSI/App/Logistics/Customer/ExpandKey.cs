using CSI.MG;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.Logistics.Customer
{
    public interface IExpandKey
    {
        int ExpandKyByType(StringNameType DataType, AlphaKeyType key, ref AlphaKeyType val);
    }

    public class ExpandKey : IExpandKey
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public ExpandKey(IApplicationDB applicationDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = applicationDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public int ExpandKyByType(StringNameType DataType, AlphaKeyType Key, ref AlphaKeyType Result)
        {
            using (var cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ExpandKyByTypeSp";
                appDB.AddCommandParameter(cmd, "DataType", DataType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Key", Key, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Result", Result, ParameterDirection.InputOutput);
                var Severity = appDB.ExecuteNonQuery(cmd);
                return Severity;
            }
        }
    }
}
