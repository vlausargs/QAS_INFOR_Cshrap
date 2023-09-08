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
    public class LowCharacterCacheFactory : ILowCharacterFactory
	{
		public ILowCharacter Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LowCharacter = new LowCharacterFactory().Create(appDB,mgInvoker,parameterProvider,calledFromIDO);
			var _LowCharacterCache = new LowCharacterCache(_LowCharacter);

			return _LowCharacterCache;
		}
	}
}
