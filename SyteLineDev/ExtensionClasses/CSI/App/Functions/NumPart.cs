using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public class NumPart : INumPart
    {
		readonly IApplicationDB appDB;

		public NumPart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public decimal NumPartFn(string Key)
        {
			AlphaKeyType _Key = Key;
			using (IDbCommand cmd = appDB.CreateCommand())
            {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select dbo.[NumPart](@Key)";

                appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal>(cmd);
                return Output;
            }
        }
    }
}
