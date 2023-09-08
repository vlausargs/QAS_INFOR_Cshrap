//PROJECT NAME: Logistics
//CLASS NAME: ExtInterfaceDoInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ExtInterfaceDoInfo : IExtInterfaceDoInfo
	{
		readonly IApplicationDB appDB;
		
		
		public ExtInterfaceDoInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DoHdrInfo,
		string DoLineInfo) ExtInterfaceDoInfoSp(string DoNum,
		string InvNum,
		int? InvSeq,
		string DoHdrInfo,
		string DoLineInfo)
		{
			DoNumType _DoNum = DoNum;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			LongListType _DoHdrInfo = DoHdrInfo;
			LongListType _DoLineInfo = DoLineInfo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtInterfaceDoInfoSp";
				
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoHdrInfo", _DoHdrInfo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DoLineInfo", _DoLineInfo, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DoHdrInfo = _DoHdrInfo;
				DoLineInfo = _DoLineInfo;
				
				return (Severity, DoHdrInfo, DoLineInfo);
			}
		}
	}
}
