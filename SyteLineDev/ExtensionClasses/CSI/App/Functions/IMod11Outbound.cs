//PROJECT NAME: Data
//CLASS NAME: IMod11Outbound.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMod11Outbound
	{
		string Mod11OutboundFn(
			string OCR);
	}
}

