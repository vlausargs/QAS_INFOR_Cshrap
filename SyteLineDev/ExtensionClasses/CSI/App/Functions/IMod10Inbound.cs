//PROJECT NAME: Data
//CLASS NAME: IMod10Inbound.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMod10Inbound
	{
		bool? Mod10InboundFn(
			string OCRRef);
	}
}

