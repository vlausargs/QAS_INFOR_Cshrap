//PROJECT NAME: Data
//CLASS NAME: IMod10Outbound.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMod10Outbound
	{
		string Mod10OutboundFn(
			string OCR);
	}
}

