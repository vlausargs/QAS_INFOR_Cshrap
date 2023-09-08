using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class PrimaryOrUniqueKeyStringFactory : IPrimaryOrUniqueKeyStringFactory
	{
		public IPrimaryOrUniqueKeyString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrimaryOrUniqueKeyString = new MGCore.PrimaryOrUniqueKeyString(appDB);


			return _PrimaryOrUniqueKeyString;
		}
	}
}
