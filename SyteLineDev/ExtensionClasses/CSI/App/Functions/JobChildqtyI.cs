//PROJECT NAME: Data
//CLASS NAME: JobChildQtyI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobChildQtyI : IJobChildQtyI
	{
		readonly IApplicationDB appDB;
		
		public JobChildQtyI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			decimal? QtyReleased,
			string Infobar) JobChildqtyISp(
			decimal? QtyReleased,
			string Units,
			decimal? MatlQty,
			int? FromExtScrap,
			decimal? JbmExtScrap,
			int? IsItemScrap,
			decimal? ShrinkFact,
			string Infobar)
		{
			QtyUnitType _QtyReleased = QtyReleased;
			JobmatlUnitsType _Units = Units;
			QtyPerType _MatlQty = MatlQty;
			ListYesNoType _FromExtScrap = FromExtScrap;
			ScrapFactorType _JbmExtScrap = JbmExtScrap;
			ListYesNoType _IsItemScrap = IsItemScrap;
			ScrapFactorType _ShrinkFact = ShrinkFact;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobChildqtyISp";

				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromExtScrap", _FromExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JbmExtScrap", _JbmExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsItemScrap", _IsItemScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShrinkFact", _ShrinkFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				QtyReleased = _QtyReleased;
				Infobar = _Infobar;

				return (Severity, QtyReleased, Infobar);
			}
		}

		public decimal? JobChildQtyIFn(
			decimal? QtyReleased,
			string Units,
			decimal? MatlQty,
			int? FromExtScrap,
			decimal? JbmExtScrap,
			int? IsItemScrap,
			decimal? ShrinkFact)
		{
			QtyUnitType _QtyReleased = QtyReleased;
			JobmatlUnitsType _Units = Units;
			QtyPerType _MatlQty = MatlQty;
			ListYesNoType _FromExtScrap = FromExtScrap;
			ScrapFactorType _JbmExtScrap = JbmExtScrap;
			ListYesNoType _IsItemScrap = IsItemScrap;
			ScrapFactorType _ShrinkFact = ShrinkFact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JobChildQtyI](@QtyReleased, @Units, @MatlQty, @FromExtScrap, @JbmExtScrap, @IsItemScrap, @ShrinkFact)";
				
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromExtScrap", _FromExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JbmExtScrap", _JbmExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsItemScrap", _IsItemScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShrinkFact", _ShrinkFact, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
