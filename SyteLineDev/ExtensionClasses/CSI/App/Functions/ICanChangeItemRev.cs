//PROJECT NAME: Data
//CLASS NAME: ICanChangeItemRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanChangeItemRev
	{
		int? CanChangeItemRevFn(
			string PItem);
	}
}

