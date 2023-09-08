//PROJECT NAME: Finance
//CLASS NAME: ILedgerDimAttributesOverrideUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ILedgerDimAttributesOverrideUpdate
	{
		int? LedgerDimAttributesOverrideUpdateSp(Guid? SubscriberObjectRowpointer,
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
		string AnalysisAttributeValue15);
	}
}

