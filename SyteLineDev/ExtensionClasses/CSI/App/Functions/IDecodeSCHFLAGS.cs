//PROJECT NAME: Data
//CLASS NAME: IDecodeSCHFLAGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDecodeSCHFLAGS
	{
		string DecodeSCHFLAGSFn(
			int? SCHFLAGS);
	}
}

