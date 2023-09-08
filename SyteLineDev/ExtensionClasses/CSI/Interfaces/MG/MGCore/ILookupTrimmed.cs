using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface ILookupTrimmed
	{
        int? LookupTrimmedFn(string Target,
        string List,
        string Delim = ",");
    }
}
