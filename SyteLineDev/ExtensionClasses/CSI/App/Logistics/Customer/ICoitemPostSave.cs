//PROJECT NAME: Logistics
//CLASS NAME: ICoitemPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemPostSave
	{
		(int? ReturnCode, string Infobar) CoitemPostSaveSp(string Infobar);
	}
}

