//PROJECT NAME: Data
//CLASS NAME: CreateSubjob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateSubjob : ICreateSubjob
	{
		readonly IApplicationDB appDB;
		
		public CreateSubjob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ToSequence,
			string Infobar) CreateSubjobSp(
			Guid? ItemRowPointer,
			string ItemJob,
			string ToJob,
			int? ToSuffix,
			int? ToOperNum,
			int? ToSequence,
			string ToJobmatlUnits,
			string JobmatlItem,
			string JobmatlRefType,
			decimal? ToJobmatlMatlQty,
			decimal? FromQtyReleased,
			string Infobar,
			string CoitemFeatStr = null,
			decimal? HrsPerDay = 0,
			int? CalcSubJobDates = 0,
			string ToType = null,
			int? CopyUetValues = 0)
		{
			RowPointerType _ItemRowPointer = ItemRowPointer;
			JobType _ItemJob = ItemJob;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			OperNumType _ToOperNum = ToOperNum;
			JobmatlSequenceType _ToSequence = ToSequence;
			JobmatlUnitsType _ToJobmatlUnits = ToJobmatlUnits;
			ItemType _JobmatlItem = JobmatlItem;
			RefTypeIJKPRTType _JobmatlRefType = JobmatlRefType;
			QtyPerType _ToJobmatlMatlQty = ToJobmatlMatlQty;
			QtyPerType _FromQtyReleased = FromQtyReleased;
			InfobarType _Infobar = Infobar;
			FeatStrType _CoitemFeatStr = CoitemFeatStr;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			ListYesNoType _CalcSubJobDates = CalcSubJobDates;
			JobTypeType _ToType = ToType;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateSubjobSp";
				
				appDB.AddCommandParameter(cmd, "ItemRowPointer", _ItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJob", _ItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOperNum", _ToOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSequence", _ToSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToJobmatlUnits", _ToJobmatlUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefType", _JobmatlRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobmatlMatlQty", _ToJobmatlMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromQtyReleased", _FromQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemFeatStr", _CoitemFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcSubJobDates", _CalcSubJobDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToSequence = _ToSequence;
				Infobar = _Infobar;
				
				return (Severity, ToSequence, Infobar);
			}
		}
	}
}
