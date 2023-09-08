//PROJECT NAME: Finance
//CLASS NAME: AddTaxFreeExport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class AddTaxFreeExport : IAddTaxFreeExport
	{
		readonly IApplicationDB appDB;
		
		public AddTaxFreeExport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AddTaxFreeExportSp(
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRelease,
			DateTime? pShipDate,
			decimal? pShipQty,
			string pExportDocId,
			string pItem,
			string pExportType,
			string Infobar)
		{
			RefTypeKOTType _pRefType = pRefType;
			CoProjTrnNumType _pRefNum = pRefNum;
			CoLineProjTaskTrnLineType _pRefLineSuf = pRefLineSuf;
			CoReleaseProjmatlSeqType _pRefRelease = pRefRelease;
			DateType _pShipDate = pShipDate;
			QtyUnitType _pShipQty = pShipQty;
			ExportDocIdType _pExportDocId = pExportDocId;
			ItemType _pItem = pItem;
			ListDirectIndirectNonExportType _pExportType = pExportType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddTaxFreeExportSp";
				
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefLineSuf", _pRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefRelease", _pRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipDate", _pShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipQty", _pShipQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExportDocId", _pExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExportType", _pExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
