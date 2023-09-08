//PROJECT NAME: Finance
//CLASS NAME: IARPaymentImportManager.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARPaymentImportManager
	{
		(int? ReturnCode,
			string Infobar) ARPaymentImportManagerSp(
			string MapId,
			string FilePath,
			string Filenames,
			int? TaskId,
			string Infobar);
	}
}

