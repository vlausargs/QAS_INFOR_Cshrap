//PROJECT NAME: Logistics
//CLASS NAME: CheckAndGetInvLength.cs

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
	public class CheckAndGetInvLeng : ICheckAndGetInvLength
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICheckInvLength iCheckInvLength;
		readonly IScalarFunction scalarFunction;
		readonly IGetKeyLength iGetKeyLength;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICheckAndGetInvLengthCRUD iCheckAndGetInvLengthCRUD;

		public CheckAndGetInvLeng(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICheckInvLength iCheckInvLength,
			IScalarFunction scalarFunction,
			IGetKeyLength iGetKeyLength,
			ISQLValueComparerUtil sQLUtil,
			ICheckAndGetInvLengthCRUD iCheckAndGetInvLengthCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCheckInvLength = iCheckInvLength;
			this.scalarFunction = scalarFunction;
			this.iGetKeyLength = iGetKeyLength;
			this.sQLUtil = sQLUtil;
			this.iCheckAndGetInvLengthCRUD = iCheckAndGetInvLengthCRUD;
		}

		public (
			int? ReturnCode,
			int? Result,
			int? KeyLength,
			int? PromptTaxDisc,
			string Infobar)
		CheckAndGetInvLength(
			string KeyName,
			int? Result,
			int? KeyLength,
			int? PromptTaxDisc,
			string Infobar)
		{

			ByteType _PromptTaxDisc = PromptTaxDisc;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCheckAndGetInvLengthCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckAndGetInvLengthCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCheckAndGetInvLengthCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCheckAndGetInvLengthCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckAndGetInvLengthCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCheckAndGetInvLengthCRUD.AltExtGen_CheckAndGetInvLength(ALTGEN_SpName,
						KeyName,
						Result,
						KeyLength,
						PromptTaxDisc,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Result, KeyLength, PromptTaxDisc, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckAndGetInvLengthCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCheckAndGetInvLengthCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckAndGetInvLength") != null)
			{
				var EXTGEN = this.iCheckAndGetInvLengthCRUD.AltExtGen_CheckAndGetInvLength("dbo.EXTGEN_CheckAndGetInvLength",
					KeyName,
					Result,
					KeyLength,
					PromptTaxDisc,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Result, EXTGEN.KeyLength, EXTGEN.PromptTaxDisc, EXTGEN.Infobar);
				}
			}

			Severity = 0;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CheckInvLengthSp
			var CheckInvLength = this.iCheckInvLength.CheckInvLengthSp(
				Result: Result,
				Infobar: Infobar);
			Severity = CheckInvLength.ReturnCode;
			Result = CheckInvLength.Result;
			Infobar = CheckInvLength.Infobar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, Result, KeyLength, PromptTaxDisc, Infobar);
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: GetKeyLengthSp
			var GetKeyLength = this.iGetKeyLength.GetKeyLengthSp(
				KeyName: KeyName,
				KeyLength: KeyLength,
				Infobar: Infobar);
			Severity = GetKeyLength.ReturnCode;
			KeyLength = GetKeyLength.KeyLength;
			Infobar = GetKeyLength.Infobar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, Result, KeyLength, PromptTaxDisc, Infobar);
			}
			(PromptTaxDisc, rowCount) = this.iCheckAndGetInvLengthCRUD.LoadTaxparms(PromptTaxDisc);
			return (Severity, Result, KeyLength, PromptTaxDisc, Infobar);

		}

	}
}
