//PROJECT NAME: Data
//CLASS NAME: ChkGrnLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChkGrnLine : IChkGrnLine
	{
		readonly IApplicationDB appDB;
		
		public ChkGrnLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QtyRec,
			decimal? QtyRej) ChkGrnLineSp(
			string VendNum,
			string GrnNum,
			decimal? QtyRec,
			decimal? QtyRej)
		{
			VendNumType _VendNum = VendNum;
			GrnNumType _GrnNum = GrnNum;
			QtyUnitType _QtyRec = QtyRec;
			QtyUnitType _QtyRej = QtyRej;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkGrnLineSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyRec", _QtyRec, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRej", _QtyRej, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyRec = _QtyRec;
				QtyRej = _QtyRej;
				
				return (Severity, QtyRec, QtyRej);
			}
		}
	}
}
