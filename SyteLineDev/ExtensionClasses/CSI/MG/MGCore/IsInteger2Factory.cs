using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IsInteger2Factory : IIsInteger2Factory
	{
		public IIsInteger2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsInteger2 = new MGCore.IsInteger2(appDB);


			return _IsInteger2;
		}
	}
}
