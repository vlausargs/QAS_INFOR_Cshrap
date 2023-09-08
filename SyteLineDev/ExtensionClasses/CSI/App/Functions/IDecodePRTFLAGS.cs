//PROJECT NAME: Data
//CLASS NAME: IDecodePRTFLAGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDecodePRTFLAGS
	{
		string DecodePRTFLAGSFn(
			int? PRTFLAGS);
	}
}

