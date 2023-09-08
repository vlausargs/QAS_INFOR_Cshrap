//PROJECT NAME: Data
//CLASS NAME: GetBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetBal : IGetBal
	{
		readonly IApplicationDB appDB;
		
		public GetBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetBalFn(
			string Item,
			DateTime? TransDate,
			int? IncludeNonNetStk,
			string WhseStarting,
			string WhseEnding,
			string LocStarting,
			string LocEnding,
			string ReasonCodeStarting,
			string ReasonCodeEnding,
			int? AllWhse,
			int? AllLoc,
			int? AllReasonCode,
			decimal? TransNum)
		{
			ItemType _Item = Item;
			DateTimeType _TransDate = TransDate;
			ListYesNoType _IncludeNonNetStk = IncludeNonNetStk;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			ReasonCodeType _ReasonCodeStarting = ReasonCodeStarting;
			ReasonCodeType _ReasonCodeEnding = ReasonCodeEnding;
			ListYesNoType _AllWhse = AllWhse;
			ListYesNoType _AllLoc = AllLoc;
			ListYesNoType _AllReasonCode = AllReasonCode;
			MatlTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetBal](@Item, @TransDate, @IncludeNonNetStk, @WhseStarting, @WhseEnding, @LocStarting, @LocEnding, @ReasonCodeStarting, @ReasonCodeEnding, @AllWhse, @AllLoc, @AllReasonCode, @TransNum)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeNonNetStk", _IncludeNonNetStk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeStarting", _ReasonCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeEnding", _ReasonCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllWhse", _AllWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllLoc", _AllLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllReasonCode", _AllReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
