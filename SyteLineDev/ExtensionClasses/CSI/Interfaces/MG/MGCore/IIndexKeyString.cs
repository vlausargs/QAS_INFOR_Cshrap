using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IIndexKeyString
	{
		string IndexKeyStringFn(string IndexName,
		string TableName);
	}
}

