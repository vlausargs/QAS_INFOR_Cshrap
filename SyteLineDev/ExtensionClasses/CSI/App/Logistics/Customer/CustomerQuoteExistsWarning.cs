//PROJECT NAME: Logistics
//CLASS NAME: CustomerQuoteExistsWarning.cs

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
	public class CustomerQuoteExistsWarning : ICustomerQuoteExistsWarning
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICustomerQuoteExistsWarningCRUD iCustomerQuoteExistsWarningCRUD;

		public CustomerQuoteExistsWarning(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICustomerQuoteExistsWarningCRUD iCustomerQuoteExistsWarningCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCustomerQuoteExistsWarningCRUD = iCustomerQuoteExistsWarningCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		CustomerQuoteExistsWarningSp(
			string CoNum,
			string CustQuote,
			string CustNum,
			string ProspectId,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCustomerQuoteExistsWarningCRUD.CheckOptional_ModuleExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCustomerQuoteExistsWarningCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCustomerQuoteExistsWarningCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCustomerQuoteExistsWarningCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCustomerQuoteExistsWarningCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCustomerQuoteExistsWarningCRUD.AltExtGen_CustomerQuoteExistsWarningSp(ALTGEN_SpName,
						CoNum,
						CustQuote,
						CustNum,
						ProspectId,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCustomerQuoteExistsWarningCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iCustomerQuoteExistsWarningCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CustomerQuoteExistsWarningSp") != null)
			{
				var EXTGEN = this.iCustomerQuoteExistsWarningCRUD.AltExtGen_CustomerQuoteExistsWarningSp("dbo.EXTGEN_CustomerQuoteExistsWarningSp",
					CoNum,
					CustQuote,
					CustNum,
					ProspectId,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Infobar = null;
			Severity = 0;
			if (this.iCustomerQuoteExistsWarningCRUD.CheckCustNumForExists(CoNum, CustQuote, CustNum))
			{

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "I=ExistFor=1",
					Parm1: "@co-e",
					Parm2: "@!CustomerQuote",
					Parm3: CustQuote,
					Parm4: "@co-e",
					Parm5: "@co.cust_num",
					Parm6: CustNum);
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

			}
			else
			{
				if (this.iCustomerQuoteExistsWarningCRUD.CheckProspectIdForExists(CoNum, CustQuote, ProspectId))
				{

					#region CRUD ExecuteMethodCall

					var MsgApp1 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "I=ExistFor=1",
						Parm1: "@co-e",
						Parm2: "@!CustomerQuote",
						Parm3: CustQuote,
						Parm4: "@co-e",
						Parm5: "@co.prospect",
						Parm6: ProspectId);
					Infobar = MsgApp1.Infobar;

					#endregion ExecuteMethodCall

				}

			}
			return (Severity, Infobar);

		}

	}
}
