using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class LookupTrimmed : ILookupTrimmed
	{
		IApplicationDB appDB;


		public LookupTrimmed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public int? LookupTrimmedFn(string Target,
        string List,
        string Delim = ",")
        {
            InfobarType _Target = Target;
            LongList _List = List;
            StringType _Delim = Delim;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[LookupTrimmed](@Target, @List, @Delim)";

                appDB.AddCommandParameter(cmd, "Target", _Target, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Delim", _Delim, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
