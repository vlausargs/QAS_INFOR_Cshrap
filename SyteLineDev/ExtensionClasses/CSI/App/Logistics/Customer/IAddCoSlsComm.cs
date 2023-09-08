//PROJECT NAME: Logistics
//CLASS NAME: IAddCoSlsComm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAddCoSlsComm
	{
		int? AddCoSlsCommSp(
			string CoNum,
			string Slsman,
			string Infobar);
	}
}

