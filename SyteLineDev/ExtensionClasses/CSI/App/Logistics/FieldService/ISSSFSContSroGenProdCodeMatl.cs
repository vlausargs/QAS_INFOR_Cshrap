//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContSroGenProdCodeMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContSroGenProdCodeMatl
	{
		(int? ReturnCode,
			string Infobar) SSSFSContSroGenProdCodeMatlSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			string ProductCode,
			int? ExtendMatl,
			string Infobar);
	}
}

