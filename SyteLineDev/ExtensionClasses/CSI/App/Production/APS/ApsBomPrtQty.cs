//PROJECT NAME: Production
//CLASS NAME: ApsBomPrtQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBomPrtQty : IApsBomPrtQty
	{
		readonly IApplicationDB appDB;
		
		public ApsBomPrtQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsBomPrtQtyFn(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? QtyReleased,
			decimal? QtyIssued,
			string Units,
			decimal? MatlQty,
			int? Precision)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyTotlType _QtyReleased = QtyReleased;
			QtyTotlType _QtyIssued = QtyIssued;
			JobmatlUnitsType _Units = Units;
			QtyTotlType _MatlQty = MatlQty;
			DecimalPlacesType _Precision = Precision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsBomPrtQty](@Job, @Suffix, @OperNum, @QtyReleased, @QtyIssued, @Units, @MatlQty, @Precision)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Precision", _Precision, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
