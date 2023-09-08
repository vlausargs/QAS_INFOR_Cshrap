//PROJECT NAME: Logistics
//CLASS NAME: IImportVATManager.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IImportVATManager
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ImportVATManagerSp(string FilePath,
		string Filenames);
	}
}

