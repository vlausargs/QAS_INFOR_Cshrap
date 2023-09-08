//PROJECT NAME: Data
//CLASS NAME: CoDConfigI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoDConfigI : ICoDConfigI
	{
		readonly IApplicationDB appDB;
		
		public CoDConfigI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) CoDConfigISp(
			int? pCoitemCoLine,
			string pCoitemCoNum,
			string pCoitemFeatStr,
			string pCoItemItem,
			Guid? pCoItemRowPointer,
			string pInvparmsFbomBlank,
			string pInvparmsFeatTempl,
			string pItemFeatTempl,
			string pItemJob,
			int? pItemPlanFlag,
			Guid? pItemRowPointer,
			int? pItemSuffix,
			DateTime? pOrderDate,
			string rInfobar)
		{
			CoLineType _pCoitemCoLine = pCoitemCoLine;
			CoNumType _pCoitemCoNum = pCoitemCoNum;
			FeatStrType _pCoitemFeatStr = pCoitemFeatStr;
			ItemType _pCoItemItem = pCoItemItem;
			RowPointerType _pCoItemRowPointer = pCoItemRowPointer;
			FeatBlankType _pInvparmsFbomBlank = pInvparmsFbomBlank;
			FeatTemplateType _pInvparmsFeatTempl = pInvparmsFeatTempl;
			FeatTemplateType _pItemFeatTempl = pItemFeatTempl;
			JobType _pItemJob = pItemJob;
			ListYesNoType _pItemPlanFlag = pItemPlanFlag;
			RowPointerType _pItemRowPointer = pItemRowPointer;
			SuffixType _pItemSuffix = pItemSuffix;
			CurrentDateType _pOrderDate = pOrderDate;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoDConfigISp";
				
				appDB.AddCommandParameter(cmd, "pCoitemCoLine", _pCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoitemCoNum", _pCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoitemFeatStr", _pCoitemFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoItemItem", _pCoItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoItemRowPointer", _pCoItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvparmsFbomBlank", _pInvparmsFbomBlank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvparmsFeatTempl", _pInvparmsFeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemFeatTempl", _pItemFeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemJob", _pItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemPlanFlag", _pItemPlanFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemRowPointer", _pItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemSuffix", _pItemSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderDate", _pOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
