//PROJECT NAME: Codes
//CLASS NAME: BuyerValid.cs

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

namespace CSI.Codes
{
	public class BuyerValid : IBuyerValid
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IBuyerValidCRUD iBuyerValidCRUD;

		public BuyerValid(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IBuyerValidCRUD iBuyerValidCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iBuyerValidCRUD = iBuyerValidCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		BuyerValidSp(
			string Buyer,
			string Infobar)
		{

			UsernameType _Buyer = Buyer;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			Guid? BuyerAvail = null;
			int? Severity = null;
			if (this.iBuyerValidCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iBuyerValidCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iBuyerValidCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iBuyerValidCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iBuyerValidCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iBuyerValidCRUD.AltExtGen_BuyerValidSp(ALTGEN_SpName,
						Buyer,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iBuyerValidCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iBuyerValidCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_BuyerValidSp") != null)
			{
				var EXTGEN = this.iBuyerValidCRUD.AltExtGen_BuyerValidSp("dbo.EXTGEN_BuyerValidSp",
					Buyer,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			if (Buyer != null)
			{
				(BuyerAvail, rowCount) = this.iBuyerValidCRUD.LoadUsernames(Buyer, BuyerAvail);
				if (BuyerAvail == null)
				{

					#region CRUD ExecuteMethodCall

					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "W=NoExist1",
						Parm1: "@item.buyer",
						Parm2: "@UserNames.UserName",
						Parm3: Buyer);
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;

					#endregion ExecuteMethodCall

				}

			}
			return (Severity, Infobar);

		}

	}
}
