//PROJECT NAME: Data
//CLASS NAME: GetItemSurcharge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemSurcharge : IGetItemSurcharge
	{
		readonly IApplicationDB appDB;
		
		public GetItemSurcharge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? SumSurcharge) GetItemSurchargeSp(
			string Item = null,
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null,
			string RefItemContent = null,
			decimal? SumSurcharge = null)
		{
			ItemType _Item = Item;
			RefTypeCEIOPRVType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			InvNumType _InvNum = InvNum;
			DateTimeType _TransDate = TransDate;
			ItemContentType _RefItemContent = RefItemContent;
			CostPrcType _SumSurcharge = SumSurcharge;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemSurchargeSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefItemContent", _RefItemContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SumSurcharge", _SumSurcharge, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SumSurcharge = _SumSurcharge;
				
				return (Severity, SumSurcharge);
			}
		}

		public decimal? GetItemSurchargeFn(
			string Item = null,
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null,
			string RefItemContent = null)
		{
			ItemType _Item = Item;
			RefTypeCEIOPRVType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			InvNumType _InvNum = InvNum;
			DateTimeType _TransDate = TransDate;
			ItemContentType _RefItemContent = RefItemContent;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetItemSurcharge](@Item, @RefType, @RefNum, @RefLine, @RefRelease, @InvNum, @TransDate, @RefItemContent)";

				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefItemContent", _RefItemContent, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
