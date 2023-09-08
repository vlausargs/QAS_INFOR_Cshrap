//PROJECT NAME: Data
//CLASS NAME: INextGLVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextGLVoucher
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextGLVoucherSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

