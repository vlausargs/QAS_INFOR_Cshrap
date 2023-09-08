//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemUMCRUD.cs

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

namespace CSI.Production.Quality
{
	public class RSQC_GetItemUMCRUD : IRSQC_GetItemUMCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		
		public RSQC_GetItemUMCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('RSQC_GetItemUMSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('RSQC_GetItemUMSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("RSQC_GetItemUMSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (string RefNum, int? RefLine, int? RefRelease, string RefType, int? rowCount) Rs_QcrcvrLoad(int? RcvrNum, string RefNum, int? RefLine, int? RefRelease, string RefType)
		{
			QCRefNumType _RefNum = DBNull.Value;
			QCRefLineType _RefLine = DBNull.Value;
			QCRefReleaseType _RefRelease = DBNull.Value;
			QCRefType _RefType = DBNull.Value;
			
			var rs_qcrcvrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_RefNum,"ref_num"},
					{_RefLine,"ref_line"},
					{_RefRelease,"ref_release"},
					{_RefType,"ref_type"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"rs_qcrcvr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("rcvr_num = {0}",RcvrNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var rs_qcrcvrLoadResponse = this.appDB.Load(rs_qcrcvrLoadRequest);
			if(rs_qcrcvrLoadResponse.Items.Count > 0)
			{
				RefNum = _RefNum;
				RefLine = _RefLine;
				RefRelease = _RefRelease;
				RefType = _RefType;
			}
			
			int rowCount = rs_qcrcvrLoadResponse.Items.Count;
			return (RefNum, RefLine, RefRelease, RefType, rowCount);
		}
		
		public (string NewUM, int? rowCount) RmaitemLoad(string RefNum, int? RefLine, string NewUM)
		{
			UMType _NewUM = DBNull.Value;
			
			var rmaitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_NewUM,"u_m"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"rmaitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("rmaitem.rma_num = {1} AND rmaitem.rma_line = {0}",RefLine,RefNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var rmaitemLoadResponse = this.appDB.Load(rmaitemLoadRequest);
			if(rmaitemLoadResponse.Items.Count > 0)
			{
				NewUM = _NewUM;
			}
			
			int rowCount = rmaitemLoadResponse.Items.Count;
			return (NewUM, rowCount);
		}
		
		public (string NewUM, int? rowCount) CoitemLoad(string RefNum, int? RefLine, string NewUM)
		{
			UMType _NewUM = DBNull.Value;
			
			var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_NewUM,"u_m"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {1} AND coitem.co_line = {0}",RefLine,RefNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
			if(coitemLoadResponse.Items.Count > 0)
			{
				NewUM = _NewUM;
			}
			
			int rowCount = coitemLoadResponse.Items.Count;
			return (NewUM, rowCount);
		}
		
		public (int? ReturnCode,
			string NewUM)
		AltExtGen_RSQC_GetItemUMSp(
			string AltExtGenSp,
			int? RcvrNum,
			string NewUM)
		{
			QCRcvrNumType _RcvrNum = RcvrNum;
			UMType _NewUM = NewUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewUM = _NewUM;
				
				return (Severity, NewUM);
			}
		}
		
	}
}
