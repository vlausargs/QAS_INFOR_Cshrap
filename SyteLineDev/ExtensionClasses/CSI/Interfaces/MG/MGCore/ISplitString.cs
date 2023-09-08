using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSI.Data.CRUD;

namespace CSI.MG.MGCore
{
	public interface ISplitString
	{
		ICollectionLoadResponse SplitStringFn(string Delimiter,
		string List);
	}
}
