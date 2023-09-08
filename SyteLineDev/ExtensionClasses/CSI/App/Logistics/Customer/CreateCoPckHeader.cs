//PROJECT NAME: Logistics
//CLASS NAME: CreateCoPckHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateCoPckHeader : ICreateCoPckHeader
	{
		readonly IApplicationDB appDB;
		
		
		public CreateCoPckHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PackNum,
		string Infobar) CreateCoPckHeaderSp(string TPckCall,
		string CoNum,
		string CustNum,
		int? CustSeq,
		string CoitemCustNum,
		int? CoitemCustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? DoLines,
		int? FromCoLine,
		int? ToCoLine,
		int? FromCoRelease,
		int? ToCoRelease,
		DateTime? FromDate,
		DateTime? ToDate,
		string CoLineStat,
		string ProcessId,
		int? PackNum,
		string Infobar,
		int? BatchId = null)
		{
			StringType _TPckCall = TPckCall;
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			CustNumType _CoitemCustNum = CoitemCustNum;
			CustSeqType _CoitemCustSeq = CoitemCustSeq;
			ShipCodeType _ShipCode = ShipCode;
			PackagesType _QtyPackages = QtyPackages;
			WeightType _Weight = Weight;
			DateType _PackDate = PackDate;
			WhseType _Whse = Whse;
			FlagNyType _DoLines = DoLines;
			CoLineType _FromCoLine = FromCoLine;
			CoLineType _ToCoLine = ToCoLine;
			CoReleaseType _FromCoRelease = FromCoRelease;
			CoReleaseType _ToCoRelease = ToCoRelease;
			DateType _FromDate = FromDate;
			DateType _ToDate = ToDate;
			StringType _CoLineStat = CoLineStat;
			InfobarType _ProcessId = ProcessId;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			BatchIdType _BatchId = BatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCoPckHeaderSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCustNum", _CoitemCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCustSeq", _CoitemCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLines", _DoLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCoLine", _FromCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCoLine", _ToCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCoRelease", _FromCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCoRelease", _ToCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDate", _FromDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDate", _ToDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLineStat", _CoLineStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PackNum = _PackNum;
				Infobar = _Infobar;
				
				return (Severity, PackNum, Infobar);
			}
		}
	}
}
