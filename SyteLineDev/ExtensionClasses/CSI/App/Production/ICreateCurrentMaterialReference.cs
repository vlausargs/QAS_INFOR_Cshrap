//PROJECT NAME: Production
//CLASS NAME: ICreateCurrentMaterialReference.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreateCurrentMaterialReference
	{
		(int? ReturnCode,
			string Infobar) CreateCurrentMaterialReferenceSp(
			string Item,
			int? JobRefOperNum,
			int? JobRefSequence,
			int? JobRefRefSeq,
			string JobRefRefDes,
			string JobRefBubble,
			string JobRefAssySeq,
			string Infobar);
	}
}

