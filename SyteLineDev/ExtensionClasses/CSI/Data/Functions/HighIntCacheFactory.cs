using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighIntCacheFactory : IHighIntFactory
    {
		public IHighInt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HighInt = new HighIntFactory().Create(appDB,mgInvoker,parameterProvider,calledFromIDO);  // new MGCore.HighInt(appDB);
			var _HighIntCache = new HighIntCache(_HighInt);

			return _HighIntCache;
		}
	}
}
