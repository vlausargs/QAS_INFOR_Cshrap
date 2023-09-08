//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSRebalCu.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSRebalCu
	{
		(int? ReturnCode,
			string Infobar) EXTSSSFSRebalCuSp(
			string StartCustNum,
			string EndCustNum,
			string Infobar);
	}
}

