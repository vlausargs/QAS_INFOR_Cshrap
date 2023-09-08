//PROJECT NAME: Logistics
//CLASS NAME: IPopulateCCITransSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPopulateCCITransSeq
	{
		int? PopulateCCITransSeqSp();
	}
}

