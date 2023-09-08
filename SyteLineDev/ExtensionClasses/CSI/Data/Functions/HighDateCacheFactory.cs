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
    public class HighDateCacheFactory: IHighDateFactory
	{
		public IHighDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HighDate = new HighDateFactory().Create(appDB,mgInvoker,parameterProvider,calledFromIDO);
			var _HighDateCache = new HighDateCache(_HighDate);

			return _HighDateCache;
		}
	}
}
