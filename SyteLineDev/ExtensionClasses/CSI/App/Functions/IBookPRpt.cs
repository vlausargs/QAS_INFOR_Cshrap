//PROJECT NAME: Data
//CLASS NAME: IBookPRpt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBookPRpt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) BookPRptSp(
			string BeginRefNum = "       ",
			string EndRefNum = "ZZZZZZZ");
	}
}

