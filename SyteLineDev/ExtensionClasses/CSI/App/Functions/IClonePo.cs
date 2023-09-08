//PROJECT NAME: Data
//CLASS NAME: IClonePo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClonePo
	{
		(int? ReturnCode,
			string ToPoNum,
			string Infobar) ClonePoSp(
			string FromPoNum,
			string ToPoNum,
			string FromPoType,
			int? CopyCharges,
			string Infobar);
	}
}

