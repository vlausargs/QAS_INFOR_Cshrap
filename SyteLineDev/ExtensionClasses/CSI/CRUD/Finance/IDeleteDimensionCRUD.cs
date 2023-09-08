//PROJECT NAME: Finance
//CLASS NAME: IDeleteDimensionCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IDeleteDimensionCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectDimensionForDelete(string ObjectName, string Dimension);
		void DeleteDimension(ICollectionLoadResponse dimensionLoadResponse);
		int? AltExtGen_DeleteDimensionSp(string AltExtGenSp, string ObjectName, string Dimension);
	}
}

