using CSI.Data.SQL.UDDT;
using CSI.MG;
using CSI.MG.MGCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    /// <summary>
    /// This cache is persisted for the duration of a mongoose session
    /// by storing data in mongoose session variables
    /// </summary>
    public class MGSessionVariableBasedCache : ICache, ISessionBasedCache
    {
        readonly ICacheEntrySerializer cacheEntrySerializer;
        readonly IUndefineVariable undefineVariable;
        readonly IDefineVariable defineVariable;
        readonly IGetVariable getVariable;

        public MGSessionVariableBasedCache(ICacheEntrySerializer cacheEntrySerializer, IUndefineVariable undefineVariable, IDefineVariable defineVariable, IGetVariable getVariable)
        {
            this.undefineVariable = undefineVariable;
            this.defineVariable = defineVariable;
            this.getVariable = getVariable;
            this.cacheEntrySerializer = cacheEntrySerializer;
        }

        public T Get<T>(string key) where T : ICachable
        {
            T retValue = default(T);
            bool getValueCorrectly = TryGet<T>(key, out retValue);
            return retValue;           
        }

        public void Insert(string key, ICachable value)
        {
            string serializedValue = cacheEntrySerializer.Serialize(value);
            (int? returnCode,string infoBar) = 
                this.defineVariable.DefineVariableSp(key, serializedValue, "");
        }

        public void Remove(string key)
        {
            (int? returnCode, string infoBar) = 
                this.undefineVariable.UndefineVariableSp(key, "");
        }

        public bool TryGet<T>(string key, out T val) //where T : ICachable
        {
            //get the value
            (int? returnCode, string serializedVal, string infoBar) =
                   this.getVariable.GetVariableSp(key, "", 0, "", "");
            if (serializedVal == null)
            {
                //cache miss
                val = default(T);
                return false;
            }

            //deserialize
            object rawVal = cacheEntrySerializer.Deserialize(serializedVal); //val may be null if a null was cached

            //convert
            if(rawVal is T)
            {
                val = (T)rawVal;
                return true;
            }
            else
            {
                val = default(T);
                return false;
            }
        }
    }
}