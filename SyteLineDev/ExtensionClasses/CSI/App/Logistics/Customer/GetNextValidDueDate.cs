//PROJECT NAME: Logistics
//CLASS NAME: GetNextValidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetNextValidDueDate : IGetNextValidDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextValidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		string Infobar) GetNextValidDueDateSp(string RefType,
		int? IsForward,
		string Site,
		DateTime? DueDate,
		string Infobar)
		{
			RefType _RefType = RefType;
			ListYesNoType _IsForward = IsForward;
			SiteType _Site = Site;
			DateType _DueDate = DueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextValidDueDateSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsForward", _IsForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				Infobar = _Infobar;
				
				return (Severity, DueDate, Infobar);
			}
		}
		public DateTime? GetNextValidDueDateFn(
			string RefType,
			int? IsForward,
			DateTime? DueDate)
		{
			RefType _RefType = RefType;
			ListYesNoType _IsForward = IsForward;
			DateType _DueDate = DueDate;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetNextValidDueDate](@RefType, @IsForward, @DueDate)";

				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsForward", _IsForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<DateTime?>(cmd);

				return Output;
			}
		}

	}
}
