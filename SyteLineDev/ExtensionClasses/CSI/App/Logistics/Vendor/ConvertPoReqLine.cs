//PROJECT NAME: Logistics
//CLASS NAME: ConvertPoReqLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ConvertPoReqLine : IConvertPoReqLine
	{
		readonly IApplicationDB appDB;
		
		public ConvertPoReqLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PErrors,
			string Infobar) ConvertPoReqLineSp(
			string PItem,
			string PPoNum,
			string PReqNum,
			int? PReqLine,
			int? PCopyText,
			int? PPoChangeOrd,
			string PErrors,
			string Infobar,
			string CostCode = null,
			int? PCreatePo = null)
		{
			ItemType _PItem = PItem;
			PoNumType _PPoNum = PPoNum;
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PReqLine = PReqLine;
			FlagNyType _PCopyText = PCopyText;
			FlagNyType _PPoChangeOrd = PPoChangeOrd;
			LongListType _PErrors = PErrors;
			InfobarType _Infobar = Infobar;
			CostCodeType _CostCode = CostCode;
			FlagNyType _PCreatePo = PCreatePo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvertPoReqLineSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqLine", _PReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCopyText", _PCopyText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoChangeOrd", _PPoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PErrors", _PErrors, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreatePo", _PCreatePo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PErrors = _PErrors;
				Infobar = _Infobar;
				
				return (Severity, PErrors, Infobar);
			}
		}
	}
}
