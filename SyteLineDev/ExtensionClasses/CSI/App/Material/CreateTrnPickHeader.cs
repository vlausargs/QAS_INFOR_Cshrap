//PROJECT NAME: Material
//CLASS NAME: CreateTrnPickHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CreateTrnPickHeader : ICreateTrnPickHeader
	{
		readonly IApplicationDB appDB;
		
		
		public CreateTrnPickHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PackNum,
		string Infobar) CreateTrnPickHeaderSp(string PTrnNum,
		string PToSite,
		string PFromWhse,
		string PToWhse,
		string PTransStatT,
		string PTransStatC,
		decimal? PWeight,
		int? PQtyPackages,
		string PShipCode,
		DateTime? PPackDate,
		string PLineStatT,
		string PLineStatC,
		int? PBegTrnLine,
		int? PEndTrnLine,
		DateTime? PBegDueDate,
		DateTime? PEndDueDate,
		int? DoLines,
		int? PackNum,
		string Infobar)
		{
			TrnNumType _PTrnNum = PTrnNum;
			SiteType _PToSite = PToSite;
			WhseType _PFromWhse = PFromWhse;
			WhseType _PToWhse = PToWhse;
			TransferStatusType _PTransStatT = PTransStatT;
			TransferStatusType _PTransStatC = PTransStatC;
			WeightType _PWeight = PWeight;
			PackagesType _PQtyPackages = PQtyPackages;
			ShipCodeType _PShipCode = PShipCode;
			DateType _PPackDate = PPackDate;
			TransferStatusType _PLineStatT = PLineStatT;
			TransferStatusType _PLineStatC = PLineStatC;
			TrnLineType _PBegTrnLine = PBegTrnLine;
			TrnLineType _PEndTrnLine = PEndTrnLine;
			DateType _PBegDueDate = PBegDueDate;
			DateType _PEndDueDate = PEndDueDate;
			ListYesNoType _DoLines = DoLines;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateTrnPickHeaderSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromWhse", _PFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransStatT", _PTransStatT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransStatC", _PTransStatC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWeight", _PWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyPackages", _PQtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipCode", _PShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPackDate", _PPackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLineStatT", _PLineStatT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLineStatC", _PLineStatC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTrnLine", _PBegTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTrnLine", _PEndTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegDueDate", _PBegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDueDate", _PEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLines", _DoLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PackNum = _PackNum;
				Infobar = _Infobar;
				
				return (Severity, PackNum, Infobar);
			}
		}
	}
}
