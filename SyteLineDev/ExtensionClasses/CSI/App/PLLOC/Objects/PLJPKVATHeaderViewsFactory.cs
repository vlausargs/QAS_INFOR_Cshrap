using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using System.Globalization;

namespace PLLOC.Objects
{
    public class PLJPKVATHeaderViewsFactory : IPLJPKVATHeaderViewsFactory
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IScalarFunction scalarFunction;
        IDateTimeUtil dateTimeUtil;

        public PLJPKVATHeaderViewsFactory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, ICollectionLoadRequestFactory collectionLoadRequestFactory, IScalarFunction scalarFunction, IDateTimeUtil dateTimeUtil)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.bunchedLoadCollection = bunchedLoadCollection ?? throw new ArgumentNullException(nameof(bunchedLoadCollection));
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.scalarFunction = scalarFunction ?? throw new ArgumentNullException(nameof(scalarFunction));
            this.dateTimeUtil = dateTimeUtil ?? throw new ArgumentNullException(nameof(dateTimeUtil));
        }

        public (IJPKV7MHeader CreateHeader, IJPKV7MEntity1 CreateEntity1) Create(
        string SiteRef,
        string TaxRegNum,
        string PLVATSystemCode,
        string PLVATStructureVersion,
        string PLVATFormVariant,
        string PLVATOfficeCode,
        string SubmissionMode,
        DateTime BeginTaxDate,
        DateTime EndTaxDate)
        {
            return (
                this.CreateHeader(PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, SubmissionMode, BeginTaxDate, EndTaxDate),
                this.CreateEntity1(appDB, bunchedLoadCollection, collectionLoadRequestFactory, SiteRef, TaxRegNum)
                    );
        }

        public (IJPKV7MHeader CreateHeader, IJPKV7MEntity1 CreateEntity1) Create(
        string SiteRef,
        string TaxRegNum,
        string PLVATSystemCode,
        string PLVATStructureVersion,
        string PLVATFormVariant,
        string PLVATOfficeCode,
        string PLVATPhone,
        string PLVATEmailAddr,
        string SubmissionMode,
        DateTime BeginTaxDate,
        DateTime EndTaxDate)
        {
            return (
                this.CreateHeader(PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, SubmissionMode, BeginTaxDate, EndTaxDate),
                this.CreateEntity1(appDB, bunchedLoadCollection, collectionLoadRequestFactory, SiteRef, TaxRegNum, PLVATPhone, PLVATEmailAddr)
                    );
        }

        private IJPKV7MHeader CreateHeader(
            string PLVATSystemCode,
            string PLVATStructureVersion,
            string PLVATFormVariant,
            string PLVATOfficeCode,
            string SubmissionMode,
            DateTime BeginTaxDate,
            DateTime EndTaxDate)
        {
            string FormSystemCode = PLVATSystemCode;
            string FormSchemaVersion = PLVATStructureVersion;
            string FormCode = "JPK_VAT";
            string FormVariant = PLVATFormVariant;
            DateTime JPKProductionDate = dateTimeUtil.Now();
            string SystemName = "Infor CSI";
            string OrderPurpose = SubmissionMode;
            string Item = "P_7";
            string OfficeCode = PLVATOfficeCode;
            int Year = dateTimeUtil.Year<int>(BeginTaxDate);
            int Month = dateTimeUtil.Month<int>(EndTaxDate);
  

            return new JPKV7MHeader(FormCode, FormSchemaVersion, FormSystemCode, FormVariant, Item, JPKProductionDate, Month, OfficeCode, OrderPurpose, SystemName, Year);
        }

        private IJPKV7MEntity1 CreateEntity1(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        string siteRef,
        string taxRegNum)
        {
            var getJPKV7MEntity1ValueFromDB = new JPKV7MEntity1Manager(appDB, bunchedLoadCollection,
                collectionLoadRequestFactory, siteRef).GetJPKV7MEntity1ValueFromDB();

            var jPKV7MEntity1 = new JPKV7MEntity1(getJPKV7MEntity1ValueFromDB.email, getJPKV7MEntity1ValueFromDB.name, getJPKV7MEntity1ValueFromDB.phone, taxRegNum);

            return jPKV7MEntity1;
        }

        private IJPKV7MEntity1 CreateEntity1(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        string siteRef,
        string taxRegNum,
        string PLVATPhone,
        string PLVATEmailAddr)
        {
            var getJPKV7MEntity1ValueFromDB = new JPKV7MEntity1Manager(appDB, bunchedLoadCollection,
                collectionLoadRequestFactory, siteRef).GetJPKV7MEntity1ValueFromDB();

            var jPKV7MEntity1 = new JPKV7MEntity1(PLVATEmailAddr, getJPKV7MEntity1ValueFromDB.name, PLVATPhone, taxRegNum);

            return jPKV7MEntity1;
        }
    }
}
