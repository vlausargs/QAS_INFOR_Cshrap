//PROJECT NAME: Production
//CLASS NAME: IApsParseSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsParseSequence
	{
		int? ApsParseSequenceFn();
	}
}

