//PROJECT NAME: Codes
//CLASS NAME: IHome_MetricProdcodeValueCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IHome_MetricProdcodeValueCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		void Tv_StagingtableInsert(ICollectionLoadResponse tv_StagingTableExecResultLoadResponse);
		ICollectionLoadResponse Tv_Stagingtable2Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricProdcodeValueSp(string AltExtGenSp);
	}
}

