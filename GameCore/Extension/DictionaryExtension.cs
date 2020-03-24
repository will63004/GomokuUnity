namespace System.Collections.Generic
{
    public static class DictionaryExtension
    {
        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> keyValuePairs, TKey key, TValue value)
        {
            if (keyValuePairs.ContainsKey(key))
                return false;

            keyValuePairs.Add(key, value);
            return true;
        }
    }
}
