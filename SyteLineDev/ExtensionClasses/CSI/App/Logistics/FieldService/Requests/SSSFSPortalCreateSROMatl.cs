//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateSROMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSPortalCreateSROMatl
	{
		(int? ReturnCode, Guid? RowPointer, string Infobar) SSSFSPortalCreateSROMatlSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PartnerID,
		DateTime? TransDate,
		string CustNum,
		string CustSeq,
		string Username,
		string Item,
		string MatlDescription,
		string UM,
		decimal? QtyConv,
		string NoteContent,
		byte? Validate = (byte)0,
		Guid? RowPointer = null,
		string Infobar = null);
	}
	
	public class SSSFSPortalCreateSROMatl : ISSSFSPortalCreateSROMatl
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalCreateSROMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer, string Infobar) SSSFSPortalCreateSROMatlSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PartnerID,
		DateTime? TransDate,
		string CustNum,
		string CustSeq,
		string Username,
		string Item,
		string MatlDescription,
		string UM,
		decimal? QtyConv,
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
			ItemType _Item = Item;
			DescriptionType _MatlDescription = MatlDescription;
			UMType _UM = UM;
			QtyUnitType _QtyConv = QtyConv;
			Infobar _NoteContent = NoteContent;
			ListYesNoType _Validate = Validate;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalCreateSROMatlSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlDescription", _MatlDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
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
