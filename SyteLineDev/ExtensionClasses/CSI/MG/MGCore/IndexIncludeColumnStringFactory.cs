using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IndexIncludeColumnStringFactory : IIndexIncludeColumnStringFactory
	{
		public IIndexIncludeColumnString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IndexIncludeColumnString = new MGCore.IndexIncludeColumnString(appDB);


			return _IndexIncludeColumnString;
		}
	}
}
