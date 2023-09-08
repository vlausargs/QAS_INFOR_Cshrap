using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class FullTextIndexColumnStringFactory : IFullTextIndexColumnStringFactory
	{
		public IFullTextIndexColumnString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FullTextIndexColumnString = new MGCore.FullTextIndexColumnString(appDB);


			return _FullTextIndexColumnString;
		}
	}
}
