using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class UserNameBySessionIdFactory : IUserNameBySessionIdFactory
	{
		public IUserNameBySessionId Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UserNameBySessionId = new UserNameBySessionId(appDB);


			return _UserNameBySessionId;
		}
	}
}
