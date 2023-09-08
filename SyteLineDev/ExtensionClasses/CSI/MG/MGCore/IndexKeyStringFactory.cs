using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IndexKeyStringFactory : IIndexKeyStringFactory
	{
		public IIndexKeyString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IndexKeyString = new MGCore.IndexKeyString(appDB);


			return _IndexKeyString;
		}
	}
}
