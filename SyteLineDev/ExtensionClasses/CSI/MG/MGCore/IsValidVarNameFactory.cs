using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IsValidVarNameFactory : IIsValidVarNameFactory
	{
		public IIsValidVarName Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsValidVarName = new MGCore.IsValidVarName(appDB);


			return _IsValidVarName;
		}
	}
}
