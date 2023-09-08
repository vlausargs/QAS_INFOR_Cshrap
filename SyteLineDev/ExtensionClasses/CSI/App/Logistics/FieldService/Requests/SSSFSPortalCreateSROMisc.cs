//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateSROMisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSPortalCreateSROMisc
	{
		(int? ReturnCode, Guid? RowPointer, string Infobar) SSSFSPortalCreateSROMiscSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PartnerID,
		DateTime? TransDate,
		string CustNum,
		string CustSeq,
		string Username,
		string MiscCode,
		string MiscCodeDesc,
		decimal? QtyConv,
		decimal? CostConv,
		string NoteContent,
		byte? Validate = (byte)0,
		Guid? RowPointer = null,
		string Infobar = null);
	}
	
	public class SSSFSPortalCreateSROMisc : ISSSFSPortalCreateSROMisc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalCreateSROMisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer, string Infobar) SSSFSPortalCreateSROMiscSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PartnerID,
		DateTime? TransDate,
		string CustNum,
		string CustSeq,
		string Username,
		string MiscCode,
		string MiscCodeDesc,
		decimal? QtyConv,
		decimal? CostConv,
		string NoteContent,
		byte? Validate = (byte)0,
		Guid? RowPointer = null,
		string Infobar = null)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			FSPartnerType _PartnerID = PartnerID;
			DateTimeType _TransDate = TransDate;
			CustNumType _CustNum = CustNum;
			CustNumType _CustSeq = CustSeq;
			UsernameType _Username = Username;
			FSMiscCodeType _MiscCode = MiscCode;
			DescriptionType _MiscCodeDesc = MiscCodeDesc;
			QtyUnitType _QtyConv = QtyConv;
			CostPrcType _CostConv = CostConv;
			StringType _NoteContent = NoteContent;
			ListYesNoType _Validate = Validate;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalCreateSROMiscSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCodeDesc", _MiscCodeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Validate", _Validate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
