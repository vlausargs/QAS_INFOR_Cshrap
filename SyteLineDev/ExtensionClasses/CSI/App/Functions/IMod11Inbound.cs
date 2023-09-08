//PROJECT NAME: Data
//CLASS NAME: IMod11Inbound.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMod11Inbound
	{
		bool? Mod11InboundFn(
			string OCRRef);
	}
}

