//PROJECT NAME: Data
//CLASS NAME: IProcessTaxFreeImport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProcessTaxFreeImport
	{
		(int? ReturnCode,
			string Infobar) ProcessTaxFreeImportSp(
			string pItem,
			string Infobar);
	}
}

