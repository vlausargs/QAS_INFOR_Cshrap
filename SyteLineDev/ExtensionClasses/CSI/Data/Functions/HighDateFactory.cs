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
	public class HighDateFactory : IHighDateFactory
	{
		public IHighDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HighDate = new HighDate(appDB);


			return _HighDate;
		}
	}
}
