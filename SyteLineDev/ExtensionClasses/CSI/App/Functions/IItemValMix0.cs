//PROJECT NAME: Data
//CLASS NAME: IItemValMix0.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemValMix0
	{
		(int? ReturnCode,
			string Infobar) ItemValMix0Sp(
			string PProdMix,
			int? PPhantomDo = 0,
			string Infobar = null);
	}
}

