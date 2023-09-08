//PROJECT NAME: Production
//CLASS NAME: JobPick.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobPick : IJobPick
	{
		readonly IApplicationDB appDB;


		public JobPick(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			int? Counter,
			string Infobar) JobPickSp(
			string Job,
			int? Suffix,
			string Whse,
			int? StartingOperNum,
			int? EndingOperNum,
			int? SortByLoc,
			int? IncludeSerialNumbers,
			int? ReprintPickListItems,
			int? PrintSecondaryLocations,
			int? ExtendByScrapFactor,
			int? PostMaterialIssues,
			decimal? PickQty,
			DateTime? PostDate,
			int? Counter,
			string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			WhseType _Whse = Whse;
			GenericIntType _StartingOperNum = StartingOperNum;
			GenericIntType _EndingOperNum = EndingOperNum;
			ListYesNoType _SortByLoc = SortByLoc;
			ListYesNoType _IncludeSerialNumbers = IncludeSerialNumbers;
			ListYesNoType _ReprintPickListItems = ReprintPickListItems;
			ListYesNoType _PrintSecondaryLocations = PrintSecondaryLocations;
			ListYesNoType _ExtendByScrapFactor = ExtendByScrapFactor;
			ListYesNoType _PostMaterialIssues = PostMaterialIssues;
			QtyUnitType _PickQty = PickQty;
			DateType _PostDate = PostDate;
			IntType _Counter = Counter;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobPickSp";

				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOperNum", _StartingOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOperNum", _EndingOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByLoc", _SortByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReprintPickListItems", _ReprintPickListItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecondaryLocations", _PrintSecondaryLocations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendByScrapFactor", _ExtendByScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostMaterialIssues", _PostMaterialIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickQty", _PickQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Counter = _Counter;
				Infobar = _Infobar;

				return (Severity, Counter, Infobar);
			}
		}
	}
}
