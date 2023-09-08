using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IUserPrincipal
    {
        string UserName { get; }
        string WorkstationID { get; }
        string Site { get; }
    }
}
