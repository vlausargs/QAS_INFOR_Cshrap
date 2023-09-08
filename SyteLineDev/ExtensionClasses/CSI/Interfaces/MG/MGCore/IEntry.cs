using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IEntry
	{
		string EntryFn(int? Entry,
		string List,
		string Delim = ",");
	}
}
