using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.MGCore
{
	public class AndSqlWhereFactory
	{
		public IAndSqlWhere Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AndSqlWhere = new AndSqlWhere(appDB);


			return _AndSqlWhere;
		}
	}
}
