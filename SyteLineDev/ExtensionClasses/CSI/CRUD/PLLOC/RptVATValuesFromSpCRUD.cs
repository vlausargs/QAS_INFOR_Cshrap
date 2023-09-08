using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;

namespace CSI.PLLOC
{
    
    public class RptVATValuesFromSpCRUD : IRptVATValuesFromSpCRUD
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IApplicationDB appDB;

        public RptVATValuesFromSpCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
        }

        public bool IsCountryCodeValid(
            string CountryCode)
        {
            StringType _CountryCode = DBNull.Value;
            bool valid = false;

            #region CRUD LoadToVariable
            var countryAScountryLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                    {_CountryCode,$"iso_country.iso_country_code"},
                    },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "country AS country",
            fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN iso_country AS iso_country ON country.iso_country_code = iso_country.iso_country_code"),
            whereClause: collectionLoadRequestFactory.Clause("iso_country.iso_country_code = {0}", CountryCode),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(countryAScountryLoadRequest);
            #endregion  LoadToVariable

            if (!_CountryCode.IsNull)
            {
                valid = true;
            }
            return valid;
        }
    }
}
