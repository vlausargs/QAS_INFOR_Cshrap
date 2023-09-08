//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSHPLinesLoadSro.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSHPLinesLoadSro
	{
		(int? ReturnCode,
			string Infobar) SSSFSSHPLinesLoadSroSp(
			string CustNum,
			int? CustSeq,
			string Infobar,
			string RefType = "S");
	}
}

