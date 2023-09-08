//PROJECT NAME: Production
//CLASS NAME: Home_GetTodaysKeyProjectValues.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class Home_GetTodaysKeyProjectValues : IHome_GetTodaysKeyProjectValues
	{
		
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IMidnightOf iMidnightOf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IHome_GetTodaysKeyProjectValuesCRUD iHome_GetTodaysKeyProjectValuesCRUD;
		
		public Home_GetTodaysKeyProjectValues(
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IMidnightOf iMidnightOf,
			ISQLValueComparerUtil sQLUtil,
			IHome_GetTodaysKeyProjectValuesCRUD iHome_GetTodaysKeyProjectValuesCRUD)
		{
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.iMidnightOf = iMidnightOf;
			this.sQLUtil = sQLUtil;
			this.iHome_GetTodaysKeyProjectValuesCRUD = iHome_GetTodaysKeyProjectValuesCRUD;
		}
		
		public (
			int? ReturnCode,
			decimal? InvoiceAmountTot,
			decimal? RevenueAmountTot)
		Home_GetTodaysKeyProjectValuesSp (
			decimal? InvoiceAmountTot,
			decimal? RevenueAmountTot)
		{
			
			AmtTotType _InvoiceAmountTot = InvoiceAmountTot;
			AmtTotType _RevenueAmountTot = RevenueAmountTot;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			DateTime? Today = null;
			if (this.iHome_GetTodaysKeyProjectValuesCRUD.Optional_ModuleForExists())
			{
                this.iHome_GetTodaysKeyProjectValuesCRUD.DeclareAltgen();

				this.iHome_GetTodaysKeyProjectValuesCRUD.Optional_Module1Insert();

				while (this.iHome_GetTodaysKeyProjectValuesCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_GetTodaysKeyProjectValuesCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_GetTodaysKeyProjectValuesCRUD.AltExtGen_Home_GetTodaysKeyProjectValuesSp (ALTGEN_SpName,
						InvoiceAmountTot,
						RevenueAmountTot);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, InvoiceAmountTot, RevenueAmountTot);
						
					}
					this.iHome_GetTodaysKeyProjectValuesCRUD.Tv_ALTGEN2Delete(ALTGEN_SpName);
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_GetTodaysKeyProjectValuesSp") != null)
			{
				var EXTGEN = this.iHome_GetTodaysKeyProjectValuesCRUD.AltExtGen_Home_GetTodaysKeyProjectValuesSp("dbo.EXTGEN_Home_GetTodaysKeyProjectValuesSp",
					InvoiceAmountTot,
					RevenueAmountTot);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.InvoiceAmountTot, EXTGEN.RevenueAmountTot);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			Severity = 0;
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			(InvoiceAmountTot, rowCount) = this.iHome_GetTodaysKeyProjectValuesCRUD.Inv_MsLoad(Today, InvoiceAmountTot);
			(RevenueAmountTot, rowCount) = this.iHome_GetTodaysKeyProjectValuesCRUD.Rev_MsLoad(Today, RevenueAmountTot);
			return (Severity, InvoiceAmountTot, RevenueAmountTot);
			
		}
		
	}
}
