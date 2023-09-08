//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSCCILevel3Load.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSCCILevel3Load
	{
		int? EXTSSSFSCCILevel3LoadSp(
			string InvNum,
			string BillType);
	}
}

