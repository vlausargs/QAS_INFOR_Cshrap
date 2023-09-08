//PROJECT NAME: Data
//CLASS NAME: IEXTSSSOPMOperReceive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSOPMOperReceive
	{
		(int? ReturnCode,
			string Infobar) EXTSSSOPMOperReceiveSp(
			string job,
			int? suffix,
			int? oper_num,
			decimal? qty_moved,
			string Infobar);
	}
}

