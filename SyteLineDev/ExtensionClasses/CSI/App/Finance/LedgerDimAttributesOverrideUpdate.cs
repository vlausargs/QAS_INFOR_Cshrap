//PROJECT NAME: Finance
//CLASS NAME: LedgerDimAttributesOverrideUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class LedgerDimAttributesOverrideUpdate : ILedgerDimAttributesOverrideUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public LedgerDimAttributesOverrideUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LedgerDimAttributesOverrideUpdateSp(Guid? SubscriberObjectRowpointer,
		string AnalysisAttributeValue01,
		string AnalysisAttributeValue02,
		string AnalysisAttributeValue03,
		string AnalysisAttributeValue04,
		string AnalysisAttributeValue05,
		string AnalysisAttributeValue06,
		string AnalysisAttributeValue07,
		string AnalysisAttributeValue08,
		string AnalysisAttributeValue09,
		string AnalysisAttributeValue10,
		string AnalysisAttributeValue11,
		string AnalysisAttributeValue12,
		string AnalysisAttributeValue13,
		string AnalysisAttributeValue14,
		string AnalysisAttributeValue15)
		{
			RowPointerType _SubscriberObjectRowpointer = SubscriberObjectRowpointer;
			DimensionValueType _AnalysisAttributeValue01 = AnalysisAttributeValue01;
			DimensionValueType _AnalysisAttributeValue02 = AnalysisAttributeValue02;
			DimensionValueType _AnalysisAttributeValue03 = AnalysisAttributeValue03;
			DimensionValueType _AnalysisAttributeValue04 = AnalysisAttributeValue04;
			DimensionValueType _AnalysisAttributeValue05 = AnalysisAttributeValue05;
			DimensionValueType _AnalysisAttributeValue06 = AnalysisAttributeValue06;
			DimensionValueType _AnalysisAttributeValue07 = AnalysisAttributeValue07;
			DimensionValueType _AnalysisAttributeValue08 = AnalysisAttributeValue08;
			DimensionValueType _AnalysisAttributeValue09 = AnalysisAttributeValue09;
			DimensionValueType _AnalysisAttributeValue10 = AnalysisAttributeValue10;
			DimensionValueType _AnalysisAttributeValue11 = AnalysisAttributeValue11;
			DimensionValueType _AnalysisAttributeValue12 = AnalysisAttributeValue12;
			DimensionValueType _AnalysisAttributeValue13 = AnalysisAttributeValue13;
			DimensionValueType _AnalysisAttributeValue14 = AnalysisAttributeValue14;
			DimensionValueType _AnalysisAttributeValue15 = AnalysisAttributeValue15;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerDimAttributesOverrideUpdateSp";
				
				appDB.AddCommandParameter(cmd, "SubscriberObjectRowpointer", _SubscriberObjectRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue01", _AnalysisAttributeValue01, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue02", _AnalysisAttributeValue02, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue03", _AnalysisAttributeValue03, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue04", _AnalysisAttributeValue04, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue05", _AnalysisAttributeValue05, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue06", _AnalysisAttributeValue06, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue07", _AnalysisAttributeValue07, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue08", _AnalysisAttributeValue08, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue09", _AnalysisAttributeValue09, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue10", _AnalysisAttributeValue10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue11", _AnalysisAttributeValue11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue12", _AnalysisAttributeValue12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue13", _AnalysisAttributeValue13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue14", _AnalysisAttributeValue14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue15", _AnalysisAttributeValue15, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
