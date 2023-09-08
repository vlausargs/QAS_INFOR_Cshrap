//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefCreateO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefCreateO : ISSSFSXrefCreateO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefCreateO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oNewCoNum,
			int? oNewCoLine,
			string Infobar) SSSFSXrefCreateOSp(
			string iFromRefType,
			string iFromRefNum,
			int? iFRomRefLineSuf,
			int? iFromRefRelease,
			string iToRefNum,
			DateTime? iOrderDate,
			string iCustNum,
			int? iCustSeq,
			string iItem,
			string iItemDesc,
			decimal? iQtyOrderedConv,
			string iUM,
			string oNewCoNum,
			int? oNewCoLine,
			string Infobar)
		{
			RefTypeIJKPRTType _iFromRefType = iFromRefType;
			FSIncNumType _iFromRefNum = iFromRefNum;
			CoLineType _iFRomRefLineSuf = iFRomRefLineSuf;
			CoReleaseType _iFromRefRelease = iFromRefRelease;
			CoNumType _iToRefNum = iToRefNum;
			DateType _iOrderDate = iOrderDate;
			CustNumType _iCustNum = iCustNum;
			CustSeqType _iCustSeq = iCustSeq;
			ItemType _iItem = iItem;
			DescriptionType _iItemDesc = iItemDesc;
			QtyUnitType _iQtyOrderedConv = iQtyOrderedConv;
			UMType _iUM = iUM;
			CoNumType _oNewCoNum = oNewCoNum;
			CoLineType _oNewCoLine = oNewCoLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefCreateOSp";
				
				appDB.AddCommandParameter(cmd, "iFromRefType", _iFromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefNum", _iFromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFRomRefLineSuf", _iFRomRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromRefRelease", _iFromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToRefNum", _iToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOrderDate", _iOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustSeq", _iCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItemDesc", _iItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQtyOrderedConv", _iQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUM", _iUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oNewCoNum", _oNewCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oNewCoLine", _oNewCoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oNewCoNum = _oNewCoNum;
				oNewCoLine = _oNewCoLine;
				Infobar = _Infobar;
				
				return (Severity, oNewCoNum, oNewCoLine, Infobar);
			}
		}
	}
}
