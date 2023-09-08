using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IVariableIsDefinedBySessionId
	{
		int? VariableIsDefinedBySessionIdFn(Guid? SessionID,
		string VariableName);
	}
}
