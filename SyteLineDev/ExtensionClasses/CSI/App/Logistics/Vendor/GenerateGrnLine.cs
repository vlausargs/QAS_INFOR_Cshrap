//PROJECT NAME: Logistics
//CLASS NAME: GenerateGrnLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateGrnLine : IGenerateGrnLine
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateGrnLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateGrnLineSp(string VendNum,
		string GrnNum,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? RcvdDate,
		int? DateSeq,
		int? FromPo,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			GrnNumType _GrnNum = GrnNum;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			DateType _RcvdDate = RcvdDate;
			DateSeqType _DateSeq = DateSeq;
			FlagNyType _FromPo = FromPo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateGrnLineSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdDate", _RcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateSeq", _DateSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPo", _FromPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
