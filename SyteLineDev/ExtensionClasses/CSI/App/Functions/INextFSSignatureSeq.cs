//PROJECT NAME: Data
//CLASS NAME: INextFSSignatureSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextFSSignatureSeq
	{
		(int? ReturnCode,
			decimal? Key,
			string Infobar) NextFSSignatureSeqSp(
			decimal? Key,
			string Infobar);
	}
}

