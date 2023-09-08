//PROJECT NAME: Production
//CLASS NAME: CreatePickHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class CreatePickHeader : ICreatePickHeader
	{
		readonly IApplicationDB appDB;
		
		
		public CreatePickHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PackNum,
		string Infobar) CreatePickHeaderSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? CustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		int? DoLines,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		int? PackNum,
		string Infobar)
		{
			StringType _TPckCall = TPckCall;
			ProjNumType _ProjNum = ProjNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ShipCodeType _ShipCode = ShipCode;
			PackagesType _QtyPackages = QtyPackages;
			WeightType _Weight = Weight;
			DateType _PackDate = PackDate;
			FlagNyType _DoLines = DoLines;
			TaskNumType _FromTaskNum = FromTaskNum;
			TaskNumType _ToTaskNum = ToTaskNum;
			ProjmatlSeqType _FromSeq = FromSeq;
			ProjmatlSeqType _ToSeq = ToSeq;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePickHeaderSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLines", _DoLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTaskNum", _FromTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTaskNum", _ToTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSeq", _FromSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSeq", _ToSeq, ParameterDirection.Input);
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
