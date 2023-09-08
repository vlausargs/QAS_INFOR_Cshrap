//PROJECT NAME: Logistics
//CLASS NAME: CitemXPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CitemXPre : ICitemXPre
	{
		readonly IApplicationDB appDB;
		
		
		public CitemXPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RefNum,
		string FromSite,
		string ParmSite,
		int? PoChangeOrd,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string Infobar,
		string FromWhse) CitemXPreSp(string SourceFile,
		string SourceRefType,
		string SourceRefNum,
		int? SourceRefLineSuf,
		int? SourceRefRelease,
		string SourceItem,
		DateTime? PDueDate,
		string RefNum,
		string FromSite,
		string ParmSite,
		int? PoChangeOrd,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string Infobar,
		string FromWhse = null)
		{
			InfobarType _SourceFile = SourceFile;
			RefTypeIJPRType _SourceRefType = SourceRefType;
			JobPoReqNumType _SourceRefNum = SourceRefNum;
			SuffixPoReqLineType _SourceRefLineSuf = SourceRefLineSuf;
			PoReleaseType _SourceRefRelease = SourceRefRelease;
			ItemType _SourceItem = SourceItem;
			DateType _PDueDate = PDueDate;
			JobPoReqNumType _RefNum = RefNum;
			SiteType _FromSite = FromSite;
			SiteType _ParmSite = ParmSite;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _PromptMsg3 = PromptMsg3;
			InfobarType _PromptButtons3 = PromptButtons3;
			InfobarType _PromptMsg4 = PromptMsg4;
			InfobarType _PromptButtons4 = PromptButtons4;
			InfobarType _PromptMsg5 = PromptMsg5;
			InfobarType _PromptButtons5 = PromptButtons5;
			InfobarType _Infobar = Infobar;
			WhseType _FromWhse = FromWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitemXPreSp";
				
				appDB.AddCommandParameter(cmd, "SourceFile", _SourceFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefNum", _SourceRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefLineSuf", _SourceRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefRelease", _SourceRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceItem", _SourceItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg3", _PromptMsg3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons3", _PromptButtons3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg4", _PromptMsg4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons4", _PromptButtons4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg5", _PromptMsg5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons5", _PromptButtons5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefNum = _RefNum;
				FromSite = _FromSite;
				ParmSite = _ParmSite;
				PoChangeOrd = _PoChangeOrd;
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				PromptMsg3 = _PromptMsg3;
				PromptButtons3 = _PromptButtons3;
				PromptMsg4 = _PromptMsg4;
				PromptButtons4 = _PromptButtons4;
				PromptMsg5 = _PromptMsg5;
				PromptButtons5 = _PromptButtons5;
				Infobar = _Infobar;
				FromWhse = _FromWhse;
				
				return (Severity, RefNum, FromSite, ParmSite, PoChangeOrd, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, PromptMsg3, PromptButtons3, PromptMsg4, PromptButtons4, PromptMsg5, PromptButtons5, Infobar, FromWhse);
			}
		}
	}
}
