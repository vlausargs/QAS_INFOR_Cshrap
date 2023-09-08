//PROJECT NAME: Data
//CLASS NAME: ISplitStringForXMTran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISplitStringForXMTran
	{
		(int? ReturnCode,
			string Char1,
			string Char2,
			string Char3,
			string Char4,
			string Char5,
			string Char6,
			string Char7,
			string Char8) SplitStringForXMTranSp(
			string StringToSplit,
			string Split1,
			string Split2,
			string Char1 = null,
			string Char2 = null,
			string Char3 = null,
			string Char4 = null,
			string Char5 = null,
			string Char6 = null,
			string Char7 = null,
			string Char8 = null);
	}
}

