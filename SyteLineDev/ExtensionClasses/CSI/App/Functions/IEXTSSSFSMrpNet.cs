//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSMrpNet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSMrpNet
	{
		int? EXTSSSFSMrpNetSp(
			Guid? ProcessId,
			string ItemItem,
			string Whse);
	}
}

