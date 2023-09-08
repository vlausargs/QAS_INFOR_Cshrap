//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSCreateApsPLNData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSCreateApsPLNData
	{
		(int? ReturnCode,
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRel,
			int? pRefSeq,
			string pTopReference) EXTSSSFSCreateApsPLNDataSp(
			string pOrderId,
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRel,
			int? pRefSeq,
			string pTopReference);
	}
}

