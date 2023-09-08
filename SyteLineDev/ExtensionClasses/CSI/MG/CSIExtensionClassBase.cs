using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL;
using CSI.MG.MGCore;
using Mongoose.IDO;
using Mongoose.IDO.DataAccess;
using Mongoose.IDO.Protocol;

namespace CSI.MG
{
    public class CSIExtensionClassBase : ExtensionClassBase, ICSIExtensionClassBase, IDisposable, IServiceProvider
    {
        
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        IMGInvoker mGInvoker;
        Mongoose.IDO.DataAccess.AppDB mGAppDB;
        IMongooseDependencies mGCoreFeatures;

        #region base components
        public virtual Mongoose.IDO.DataAccess.AppDB MGAppDB
        {
            get
            {
                if (mGAppDB == null)
                    mGAppDB = CreateAppDB();
                return mGAppDB;
            }
        }
        public IApplicationDB AppDB
        {
            get
            {
                if (appDB == null)
                    appDB = new CSIAppDBFactory().CreateAppDB(MGAppDB, Context, GetMessageProvider());                
                return appDB;
            }
        }
        public virtual new IIDOExtensionClassContext Context { get { return base.Context; } }
        public IBunchedLoadCollection BunchedLoadCollection
        {
            get
            {
                if (bunchedLoadCollection == null)
                    bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB,
                (Mongoose.IDO.Protocol.LoadCollectionDataBase)this.Context.Request);                
                return bunchedLoadCollection;
            }
        }

        public IMGInvoker MGInvoker
        {
            get
            {
                if (mGInvoker == null)
                    mGInvoker = new MGInvoker(Context);                
                return mGInvoker;
            }
        }

        public IParameterProvider ParameterProvider => new SQLParameterProvider();
        public virtual IRuntimeContext RuntimeContext => IDORuntime.Context;
        [Obsolete("Please use IUserPrincipal. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public string UserName
        {
            get { return IDORuntime.Context.UserName; }
        }
        public virtual new Mongoose.IDO.IMessageProvider GetMessageProvider() { return base.GetMessageProvider(); }
       
        public IMongooseDependencies MongooseDependencies
        {
            get
            {
                if (mGCoreFeatures == null)                
                    mGCoreFeatures = new MGCoreFeaturesFactory().Create(this);                
                return mGCoreFeatures;
            }
        }
        //public ISQLDependencies SQLDependencies
        //{
        //    get
        //    {
        //        if (sqlFeatures == null)
        //            sqlFeatures = new SQLFeatures();
        //        return sqlFeatures;
        //    }
        //}

        public IUserMessageLogger UserMessageLogger => new Logger.UserMessageLogger();

        private ICache memoryCache;
        public ICache MemoryCache
        {
            get
            {
                if (memoryCache == null)
                    memoryCache = new IDOMethodCallBoundedMemoryCache();
                return memoryCache;
            }
        }

        public bool FireApplicationEvent(
            string eventName,
            bool synchronous,
            bool transactional,
            out string result,
            ref CSIApplicationEventParameter[] parameters)
        {
            var mgApplicationEventParameter = ConvertToApplicationEventParameter(parameters);
            return this.FireApplicationEvent(
                eventName,
                synchronous,
                transactional,
                out result,
                ref mgApplicationEventParameter);
        }

        public ApplicationEventParameter[] ConvertToApplicationEventParameter(
            CSIApplicationEventParameter[] parameters)
        {
            var mgApplicationEventParameter =
                new ApplicationEventParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                mgApplicationEventParameter[i].Name = parameters[i].Name;
                mgApplicationEventParameter[i].Value = parameters[i].Value;
                mgApplicationEventParameter[i].Output = parameters[i].Output;
            }

            return mgApplicationEventParameter;
        }

        #endregion
        void IDisposable.Dispose()
        {
            MGAppDB.Dispose();
            base.Dispose();
        }

        IServiceProvider serviceProvider;
        public virtual object GetService(Type serviceType)
        {
            //Comment this code line beacause it might cause partial trust problem. When an IDO method is called multiples time within one IDO Request, the problem appears.
            //if (serviceProvider == null) 
            serviceProvider = (new CompositionRoot()).BuildMongooseBasedServiceProvider(new MGCoreFeatures(this));
            return serviceProvider.GetService(serviceType);
        }        
    }
}