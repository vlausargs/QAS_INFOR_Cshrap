//PROJECT NAME: Material
//CLASS NAME: TransferLossTrnLineValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TransferLossTrnLineValid : ITransferLossTrnLineValid
	{
		readonly IApplicationDB appDB;
		
		
		public TransferLossTrnLineValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TnrSite,
		string TnrWhse,
		string PLot,
		int? FromLotTracked,
		int? UseFromSite,
		int? GenerateSerialNos,
		string RemoteSerialPrefix,
		string Infobar,
		string PImportDocId,
		int? FromTaxFreeMatl) TransferLossTrnLineValidSp(string PTrnNum,
		int? PTrnLine,
		string TnrSite,
		string TnrWhse,
		string PLot,
		int? FromLotTracked,
		int? UseFromSite,
		int? GenerateSerialNos,
		string RemoteSerialPrefix,
		string Infobar,
		string PImportDocId,
		int? FromTaxFreeMatl)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			SiteType _TnrSite = TnrSite;
			WhseType _TnrWhse = TnrWhse;
			LotType _PLot = PLot;
			ListYesNoType _FromLotTracked = FromLotTracked;
			ListYesNoType _UseFromSite = UseFromSite;
			ListYesNoType _GenerateSerialNos = GenerateSerialNos;
			SerialPrefixType _RemoteSerialPrefix = RemoteSerialPrefix;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ListYesNoType _FromTaxFreeMatl = FromTaxFreeMatl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferLossTrnLineValidSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TnrSite", _TnrSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TnrWhse", _TnrWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLotTracked", _FromLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseFromSite", _UseFromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GenerateSerialNos", _GenerateSerialNos, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSerialPrefix", _RemoteSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromTaxFreeMatl", _FromTaxFreeMatl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TnrSite = _TnrSite;
				TnrWhse = _TnrWhse;
				PLot = _PLot;
				FromLotTracked = _FromLotTracked;
				UseFromSite = _UseFromSite;
				GenerateSerialNos = _GenerateSerialNos;
				RemoteSerialPrefix = _RemoteSerialPrefix;
				Infobar = _Infobar;
				PImportDocId = _PImportDocId;
				FromTaxFreeMatl = _FromTaxFreeMatl;
				
				return (Severity, TnrSite, TnrWhse, PLot, FromLotTracked, UseFromSite, GenerateSerialNos, RemoteSerialPrefix, Infobar, PImportDocId, FromTaxFreeMatl);
			}
		}
	}
}
