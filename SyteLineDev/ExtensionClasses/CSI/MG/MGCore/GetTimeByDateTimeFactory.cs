using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class GetTimeByDateTimeFactory : IGetTimeByDateTimeFactory
	{
		public IGetTimeByDateTime Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetTimeByDateTime = new MGCore.GetTimeByDateTime(appDB);


			return _GetTimeByDateTime;
		}
	}
}
