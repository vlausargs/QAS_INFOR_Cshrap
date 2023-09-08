using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class UserPrincipal : IUserPrincipal
    {
        public string UserName => IDORuntime.Context.UserName;

        public string WorkstationID => IDORuntime.Context.WorkstationLogin;

        public string Site => IDORuntime.Context.Site;
    }
}
