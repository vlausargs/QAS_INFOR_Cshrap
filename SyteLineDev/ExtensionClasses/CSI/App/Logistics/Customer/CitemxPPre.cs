//PROJECT NAME: Logistics
//CLASS NAME: CitemxPPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CitemxPPre : ICitemxPPre
	{
		readonly IApplicationDB appDB;
		
		public CitemxPPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PoChangeOrd,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string PromptMsg3,
			string PromptButtons3,
			string PromptMsg4,
			string PromptButtons4,
			string Infobar) CitemxPPreSp(
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			string SourceItem,
			DateTime? PDueDate,
			int? PoChangeOrd,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string PromptMsg3,
			string PromptButtons3,
			string PromptMsg4,
			string PromptButtons4,
			string Infobar)
		{
			RefTypeIJPRType _SourceRefType = SourceRefType;
			JobPoReqNumType _SourceRefNum = SourceRefNum;
			SuffixPoReqLineType _SourceRefLineSuf = SourceRefLineSuf;
			ItemType _SourceItem = SourceItem;
			DateType _PDueDate = PDueDate;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _PromptMsg3 = PromptMsg3;
			InfobarType _PromptButtons3 = PromptButtons3;
			InfobarType _PromptMsg4 = PromptMsg4;
			InfobarType _PromptButtons4 = PromptButtons4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitemxPPreSp";
				
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefNum", _SourceRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefLineSuf", _SourceRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceItem", _SourceItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg3", _PromptMsg3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons3", _PromptButtons3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg4", _PromptMsg4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons4", _PromptButtons4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoChangeOrd = _PoChangeOrd;
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				PromptMsg3 = _PromptMsg3;
				PromptButtons3 = _PromptButtons3;
				PromptMsg4 = _PromptMsg4;
				PromptButtons4 = _PromptButtons4;
				Infobar = _Infobar;
				
				return (Severity, PoChangeOrd, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, PromptMsg3, PromptButtons3, PromptMsg4, PromptButtons4, Infobar);
			}
		}
	}
}
