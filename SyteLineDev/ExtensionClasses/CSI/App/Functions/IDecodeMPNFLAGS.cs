//PROJECT NAME: Data
//CLASS NAME: IDecodeMPNFLAGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDecodeMPNFLAGS
	{
		string DecodeMPNFLAGSFn(
			int? MPNFLAGS);
	}
}

