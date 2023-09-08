//PROJECT NAME: Logistics
//CLASS NAME: IImportVATFiles.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IImportVATFiles
	{
		int? ImportVATFilesSp(int? PAction,
		string PInvNum,
		string PVATInvNum,
		decimal? PVATSalesTax,
		decimal? PSalesTax);
	}
}

