using System.Collections.Generic;


public class DataStore {
    private static Dictionary<string, System.Object> values = new Dictionary<string, System.Object>();

    public static System.Object getValue(string key, System.Object defaultValue)
    {
        return values.ContainsKey(key) ? values[key] : defaultValue;
    }

    public static void setValue(string key, System.Object obj)
    {
        values[key] = obj;
    }
}
