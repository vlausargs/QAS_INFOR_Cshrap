//PROJECT NAME: Finance
//CLASS NAME: ICHSGLGenData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGLGenData
	{
		int? CHSGLGenDataSP(
			DateTime? sdate,
			DateTime? edate);
	}
}

