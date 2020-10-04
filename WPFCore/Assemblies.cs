using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WPFCore
{
    public class Assemblies
    {
        private static List<Assembly> _assemblies = new List<Assembly>();

        public static void Add(Assembly assembly)
        {
            _assemblies.Add(assembly);
        }

        public static Type FindType(string name)
        {
            return _assemblies.SelectMany(a => a.ExportedTypes).Where(e => e.FullName == name).FirstOrDefault();
        }
    }
}
