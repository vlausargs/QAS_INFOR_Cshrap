//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateIPReceiver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateIPReceiver : IRSQC_CreateIPReceiver
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateIPReceiver(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar) RSQC_CreateIPReceiverSp(decimal? i_QtyReceived,
		string i_Whse,
		string i_Job,
		int? i_Suffix,
		int? i_OperNum,
		string i_PSNum,
		string i_CallingFunction,
		string i_UserCode,
		int? firstarticleonly,
		int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar)
		{
			QtyUnitType _i_QtyReceived = i_QtyReceived;
			WhseType _i_Whse = i_Whse;
			JobType _i_Job = i_Job;
			SuffixType _i_Suffix = i_Suffix;
			OperNumType _i_OperNum = i_OperNum;
			PsNumType _i_PSNum = i_PSNum;
			DescriptionType _i_CallingFunction = i_CallingFunction;
			UserCodeType _i_UserCode = i_UserCode;
			ListYesNoType _firstarticleonly = firstarticleonly;
			ListYesNoType _o_PopUp = o_PopUp;
			ListYesNoType _o_PrintTag = o_PrintTag;
			InfobarType _o_RcvrNums = o_RcvrNums;
			InfobarType _o_Messages = o_Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateIPReceiverSp";
				
				appDB.AddCommandParameter(cmd, "i_QtyReceived", _i_QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Whse", _i_Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Job", _i_Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Suffix", _i_Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_OperNum", _i_OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_PSNum", _i_PSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_CallingFunction", _i_CallingFunction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_UserCode", _i_UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "firstarticleonly", _firstarticleonly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_PopUp", _o_PopUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_PrintTag", _o_PrintTag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RcvrNums", _o_RcvrNums, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_Messages", _o_Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_PopUp = _o_PopUp;
				o_PrintTag = _o_PrintTag;
				o_RcvrNums = _o_RcvrNums;
				o_Messages = _o_Messages;
				Infobar = _Infobar;
				
				return (Severity, o_PopUp, o_PrintTag, o_RcvrNums, o_Messages, Infobar);
			}
		}
	}
}
