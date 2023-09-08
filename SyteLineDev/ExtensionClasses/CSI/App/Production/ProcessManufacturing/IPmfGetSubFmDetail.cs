//PROJECT NAME: Production
//CLASS NAME: IPmfGetSubFmDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetSubFmDetail
	{
		(int? ReturnCode,
			string WipItem,
			string Um,
			string FmDesc) PmfGetSubFmDetailSp(
			Guid? SubFmRp,
			string WipItem,
			string Um,
			string FmDesc);
	}
}

