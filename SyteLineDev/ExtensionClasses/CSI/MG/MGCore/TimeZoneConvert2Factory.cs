using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class TimeZoneConvert2Factory : ITimeZoneConvert2Factory
	{
		public ITimeZoneConvert2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TimeZoneConvert2 = new MGCore.TimeZoneConvert2(appDB);


			return _TimeZoneConvert2;
		}
	}
}
