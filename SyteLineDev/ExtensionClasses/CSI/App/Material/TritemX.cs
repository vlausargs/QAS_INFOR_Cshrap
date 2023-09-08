//PROJECT NAME: CSIMaterial
//CLASS NAME: TritemX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ITritemX
	{
		int TritemXSp(string TrnitemTrnNum,
		              short? TrnitemTrnLine,
		              string TrnitemFrmRefType,
		              string TrnitemFrmRefNum,
		              short? TrnitemFrmRefLineSuf,
		              short? TrnitemFrmRefRelease,
		              string TrnitemItem,
		              string TrnitemUM,
		              string TrnitemStat,
		              decimal? TrnitemQtyReq,
		              DateTime? TrnitemSchShipDate,
		              DateTime? TrnitemSchRcvDate,
		              string TransferStat,
		              string TransferFromWhse,
		              ref short? CurSuffix,
		              ref string TXrefDestination,
		              ref byte? CreateFlag,
		              ref string PromptMsg,
		              ref string PromptButtons,
		              ref string Infobar);
	}
	
	public class TritemX : ITritemX
	{
		readonly IApplicationDB appDB;
		
		public TritemX(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int TritemXSp(string TrnitemTrnNum,
		                     short? TrnitemTrnLine,
		                     string TrnitemFrmRefType,
		                     string TrnitemFrmRefNum,
		                     short? TrnitemFrmRefLineSuf,
		                     short? TrnitemFrmRefRelease,
		                     string TrnitemItem,
		                     string TrnitemUM,
		                     string TrnitemStat,
		                     decimal? TrnitemQtyReq,
		                     DateTime? TrnitemSchShipDate,
		                     DateTime? TrnitemSchRcvDate,
		                     string TransferStat,
		                     string TransferFromWhse,
		                     ref short? CurSuffix,
		                     ref string TXrefDestination,
		                     ref byte? CreateFlag,
		                     ref string PromptMsg,
		                     ref string PromptButtons,
		                     ref string Infobar)
		{
			TrnNumType _TrnitemTrnNum = TrnitemTrnNum;
			TrnLineType _TrnitemTrnLine = TrnitemTrnLine;
			RefTypeIJPRType _TrnitemFrmRefType = TrnitemFrmRefType;
			JobPoReqNumType _TrnitemFrmRefNum = TrnitemFrmRefNum;
			SuffixPoReqLineType _TrnitemFrmRefLineSuf = TrnitemFrmRefLineSuf;
			PoReleaseType _TrnitemFrmRefRelease = TrnitemFrmRefRelease;
			ItemType _TrnitemItem = TrnitemItem;
			UMType _TrnitemUM = TrnitemUM;
			TransferStatusType _TrnitemStat = TrnitemStat;
			QtyUnitType _TrnitemQtyReq = TrnitemQtyReq;
			DateType _TrnitemSchShipDate = TrnitemSchShipDate;
			DateType _TrnitemSchRcvDate = TrnitemSchRcvDate;
			TransferStatusType _TransferStat = TransferStat;
			WhseType _TransferFromWhse = TransferFromWhse;
			SuffixPoReqLineType _CurSuffix = CurSuffix;
			InfobarType _TXrefDestination = TXrefDestination;
			FlagNyType _CreateFlag = CreateFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TritemXSp";
				
				appDB.AddCommandParameter(cmd, "TrnitemTrnNum", _TrnitemTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTrnLine", _TrnitemTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefType", _TrnitemFrmRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefNum", _TrnitemFrmRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefLineSuf", _TrnitemFrmRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefRelease", _TrnitemFrmRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemItem", _TrnitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUM", _TrnitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemStat", _TrnitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReq", _TrnitemQtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSchShipDate", _TrnitemSchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSchRcvDate", _TrnitemSchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferStat", _TransferStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromWhse", _TransferFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurSuffix", _CurSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TXrefDestination", _TXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurSuffix = _CurSuffix;
				TXrefDestination = _TXrefDestination;
				CreateFlag = _CreateFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
