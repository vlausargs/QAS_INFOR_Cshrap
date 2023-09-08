//PROJECT NAME: Data
//CLASS NAME: GlAlloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GlAlloc : IGlAlloc
	{
		readonly IApplicationDB appDB;
		
		public GlAlloc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? DomAmount,
			decimal? DomRemainder,
			decimal? ForAmount,
			decimal? ForRemainder,
			decimal? TotalPercent,
			string Infobar) GlAllocSp(
			decimal? DomAmount,
			decimal? DomPAmount,
			decimal? DomRemainder,
			int? DomPlaces,
			decimal? ForAmount,
			decimal? ForPAmount,
			decimal? ForRemainder,
			int? ForPlaces,
			string AllocationBasisType,
			decimal? AllocationBasisRate,
			decimal? TotalPercent,
			string Infobar)
		{
			AmountType _DomAmount = DomAmount;
			AmountType _DomPAmount = DomPAmount;
			AmountType _DomRemainder = DomRemainder;
			DecimalPlacesType _DomPlaces = DomPlaces;
			AmountType _ForAmount = ForAmount;
			AmountType _ForPAmount = ForPAmount;
			AmountType _ForRemainder = ForRemainder;
			DecimalPlacesType _ForPlaces = ForPlaces;
			AllocationBasisTypeType _AllocationBasisType = AllocationBasisType;
			AllocationBasisRateType _AllocationBasisRate = AllocationBasisRate;
			ChartDPercentType _TotalPercent = TotalPercent;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlAllocSp";
				
				appDB.AddCommandParameter(cmd, "DomAmount", _DomAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomPAmount", _DomPAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomRemainder", _DomRemainder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomPlaces", _DomPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmount", _ForAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForPAmount", _ForPAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForRemainder", _ForRemainder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForPlaces", _ForPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllocationBasisType", _AllocationBasisType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllocationBasisRate", _AllocationBasisRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalPercent", _TotalPercent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DomAmount = _DomAmount;
				DomRemainder = _DomRemainder;
				ForAmount = _ForAmount;
				ForRemainder = _ForRemainder;
				TotalPercent = _TotalPercent;
				Infobar = _Infobar;
				
				return (Severity, DomAmount, DomRemainder, ForAmount, ForRemainder, TotalPercent, Infobar);
			}
		}
	}
}
