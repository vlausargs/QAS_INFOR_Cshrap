//PROJECT NAME: Data
//CLASS NAME: IFTConvertTransTypeAtoI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTConvertTransTypeAtoI
	{
		int? FTConvertTransTypeAtoIFn(
			string tran_type = null);
	}
}

