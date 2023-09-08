using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IUserNameBySessionId
	{
		string UserNameBySessionIdFn(Guid? SessionID);
	}
}
