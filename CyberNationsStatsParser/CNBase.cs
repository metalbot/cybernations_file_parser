using System;
using System.Collections.Generic;
using System.Reflection;

namespace CyberNationsStatsParser
{
    /// <summary>
    /// Arbitrary abstract class used to constrain types on the FileParser
    /// </summary>
    public abstract class CNBase
    {
        public virtual Dictionary<string, string> CNColumnMapper()
        {
            return null;
        }

        public virtual void Display()
        {
            PropertyInfo[] pi = GetType().GetProperties();
            foreach (var info in pi)
            {
                Console.WriteLine("{0}:{1}", info.Name, info.GetValue(this));
            }
        }
    }
}
