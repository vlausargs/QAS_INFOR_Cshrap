//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricJobWIP.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class Home_MetricJobWIP : IHome_MetricJobWIP
	{
		
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IHome_MetricJobWIPCRUD iHome_MetricJobWIPCRUD;
		
		public Home_MetricJobWIP(
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IHome_MetricJobWIPCRUD iHome_MetricJobWIPCRUD)
		{
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iHome_MetricJobWIPCRUD = iHome_MetricJobWIPCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Home_MetricJobWIPSp (
			int? Count = 5)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iHome_MetricJobWIPCRUD.Optional_ModuleForExists())
			{
                this.iHome_MetricJobWIPCRUD.DeclareAltgen();

				this.iHome_MetricJobWIPCRUD.Optional_Module1Insert();

				while (this.iHome_MetricJobWIPCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_MetricJobWIPCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_MetricJobWIPCRUD.AltExtGen_Home_MetricJobWIPSp (ALTGEN_SpName,
						Count);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.iHome_MetricJobWIPCRUD.Tv_ALTGEN2Delete(ALTGEN_SpName);
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricJobWIPSp") != null)
			{
				var EXTGEN = this.iHome_MetricJobWIPCRUD.AltExtGen_Home_MetricJobWIPSp("dbo.EXTGEN_Home_MetricJobWIPSp",
					Count);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			Severity = 0;
			if (sQLUtil.SQLGreaterThan(Count, 0) == true)
			{
				var jobLoadResponse = this.iHome_MetricJobWIPCRUD.JobSelect(Count);
				Data = jobLoadResponse;
				
			}
			else
			{
				var job1LoadResponse = this.iHome_MetricJobWIPCRUD.Job1Select();
				Data = job1LoadResponse;
				
			}
			return (Data, Severity);
			
		}
		
	}
}
