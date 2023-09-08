//PROJECT NAME: Production
//CLASS NAME: IPmfGetNextRecall.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetNextRecall
	{
		(int? ReturnCode,
			string Key,
			string Infobar) PmfGetNextRecallSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar = null);
	}
}

