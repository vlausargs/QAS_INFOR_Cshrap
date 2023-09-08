//PROJECT NAME: Data
//CLASS NAME: IEdiOutPoitemDropaddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPoitemDropaddr
	{
		(int? ReturnCode,
			string Infobar) EdiOutPoitemDropaddrSp(
			string PoitemDropShipNo,
			int? PoitemDropSeq,
			string PoitemShipAddr,
			string PoitemWhse,
			Guid? EdiPoitemRowPointer,
			string Infobar);
	}
}

