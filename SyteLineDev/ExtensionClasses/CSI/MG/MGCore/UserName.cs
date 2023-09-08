using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
    public class UserName : IUserName
    {
        public string GetUserName()
        {
            return IDORuntime.Context.UserName;
        }

        public string UserNameSp()
        {
            return GetUserName();
        }
    }
}
