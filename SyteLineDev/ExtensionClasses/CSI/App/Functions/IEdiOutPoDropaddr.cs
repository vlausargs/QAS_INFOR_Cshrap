//PROJECT NAME: Data
//CLASS NAME: IEdiOutPoDropaddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPoDropaddr
	{
		(int? ReturnCode,
			string Infobar) EdiOutPoDropaddrSp(
			string PoDropShipNo,
			int? PoDropSeq,
			string PoShipAddr,
			string PoWhse,
			Guid? EdiPoRowPointer,
			string Infobar);
	}
}

