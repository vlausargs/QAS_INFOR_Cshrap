using Mongoose.IDO.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGAddCommandParameterWithValue : IAddCommandParameterWithValue
    {
        AppDB mgAppDb;

        public MGAddCommandParameterWithValue(AppDB mgAppDb)
        {
            this.mgAppDb = mgAppDb;
        }

        public IDbDataParameter AddCommandParameterWithValue(IDbCommand cmd, string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            return mgAppDb.AddCommandParameterWithValue(cmd, name, value, direction);
        }
    }
}