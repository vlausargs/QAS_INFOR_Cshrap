//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIarpmtDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIarpmtDel
	{
		(int? ReturnCode,
			string Infobar) EXTSSSCCIarpmtDelSp(
			string CustNum,
			int? CheckNum,
			string Infobar);
	}
}

