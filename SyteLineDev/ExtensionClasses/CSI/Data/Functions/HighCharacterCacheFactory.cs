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
    public class HighCharacterCacheFactory: IHighCharacterFactory
    {
		public IHighCharacter Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HighCharacter = new HighCharacterFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var _HighCharacterCache = new HighCharacterCache(_HighCharacter);

			return _HighCharacterCache;
		}
	}
}
