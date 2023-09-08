//PROJECT NAME: Logistics
//CLASS NAME: BuyerAlerts.cs

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
using CSI.Codes;

namespace CSI.Logistics.Vendor
{
	public class BuyerAlerts : IBuyerAlerts
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ICountTasksAndMessages iCountTasksAndMessages;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IMidnightOf iMidnightOf;
		readonly IUserPrincipal iUserPrincipal;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IBuyerAlertsCRUD iBuyerAlertsCRUD;

		public BuyerAlerts(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ICountTasksAndMessages iCountTasksAndMessages,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IMidnightOf iMidnightOf,
			IUserPrincipal iUserPrincipal,
			ISQLValueComparerUtil sQLUtil,
			IBuyerAlertsCRUD iBuyerAlertsCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iCountTasksAndMessages = iCountTasksAndMessages;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.iMidnightOf = iMidnightOf;
			this.iUserPrincipal = iUserPrincipal;
			this.sQLUtil = sQLUtil;
			this.iBuyerAlertsCRUD = iBuyerAlertsCRUD;
		}

		public (
			int? ReturnCode,
			int? OverDuePOLines,
			int? OverDuePOReleases,
			int? NumberOfUserTasks,
			int? NumberOfEventMessages)
		BuyerAlertsSp(
			int? OverDuePOLines,
			int? OverDuePOReleases,
			int? NumberOfUserTasks,
			int? NumberOfEventMessages)
		{

			NumberOfLinesType _OverDuePOLines = OverDuePOLines;
			NumberOfLinesType _OverDuePOReleases = OverDuePOReleases;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			DateTime? Today = null;
			string Buyer = null;
			if (this.iBuyerAlertsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iBuyerAlertsCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iBuyerAlertsCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iBuyerAlertsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iBuyerAlertsCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iBuyerAlertsCRUD.AltExtGen_BuyerAlertsSp(ALTGEN_SpName,
						OverDuePOLines,
						OverDuePOReleases,
						NumberOfUserTasks,
						NumberOfEventMessages);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, OverDuePOLines, OverDuePOReleases, NumberOfUserTasks, NumberOfEventMessages);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iBuyerAlertsCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iBuyerAlertsCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_BuyerAlertsSp") != null)
			{
				var EXTGEN = this.iBuyerAlertsCRUD.AltExtGen_BuyerAlertsSp("dbo.EXTGEN_BuyerAlertsSp",
					OverDuePOLines,
					OverDuePOReleases,
					NumberOfUserTasks,
					NumberOfEventMessages);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.OverDuePOLines, EXTGEN.OverDuePOReleases, EXTGEN.NumberOfUserTasks, EXTGEN.NumberOfEventMessages);
				}
			}

			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			Buyer = this.iUserPrincipal.UserName;
			OverDuePOLines = 0;
			(OverDuePOLines, rowCount) = this.iBuyerAlertsCRUD.LoadPOLinesCount(Today, Buyer, OverDuePOLines);
			OverDuePOReleases = 0;
			(OverDuePOReleases, rowCount) = this.iBuyerAlertsCRUD.LoadPOReleasesCount(Today, Buyer, OverDuePOReleases);

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CountTasksAndMessagesSp
			var CountTasksAndMessages = this.iCountTasksAndMessages.CountTasksAndMessagesSp(
				NumberOfUserTasks: NumberOfUserTasks,
				NumberOfEventMessages: NumberOfEventMessages);
			NumberOfUserTasks = CountTasksAndMessages.NumberOfUserTasks;
			NumberOfEventMessages = CountTasksAndMessages.NumberOfEventMessages;

			#endregion ExecuteMethodCall

			return (Severity, OverDuePOLines, OverDuePOReleases, NumberOfUserTasks, NumberOfEventMessages);

		}

	}
}
