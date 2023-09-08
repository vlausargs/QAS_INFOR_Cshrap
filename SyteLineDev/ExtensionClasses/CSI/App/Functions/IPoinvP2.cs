//PROJECT NAME: Data
//CLASS NAME: IPoinvP2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoinvP2
	{
		int? PoinvP2Sp(
			string PPoNum,
			int? PSeqNum);
	}
}

