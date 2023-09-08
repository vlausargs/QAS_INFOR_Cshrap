using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
	public class DataTypeStringFactory : IDataTypeStringFactory
	{
		public IDataTypeString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DataTypeString = new MGCore.DataTypeString(appDB);


			return _DataTypeString;
		}
	}
}
