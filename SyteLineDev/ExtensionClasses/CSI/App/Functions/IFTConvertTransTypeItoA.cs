//PROJECT NAME: Data
//CLASS NAME: IFTConvertTransTypeItoA.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTConvertTransTypeItoA
	{
		string FTConvertTransTypeItoAFn(
			string tran_type = null);
	}
}

