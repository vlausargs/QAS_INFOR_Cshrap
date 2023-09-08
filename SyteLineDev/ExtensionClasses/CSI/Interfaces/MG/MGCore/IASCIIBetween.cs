using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IASCIIBetween
	{
		bool? ASCIIBetweenFn(string Expr,
		string Starting,
		string Ending);
	}
}
