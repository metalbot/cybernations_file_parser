using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CyberNationsStatsParser
{
    /// <summary>
    /// The generic FileParser acts as an IEnumberable for generic CN objects (Alliance, Nation, War, ForeignAid).  There
    /// is some significant coupling here between the source on the StreamReader and the underlying generic.  There needs
    /// to be either a mapping from the CN column name (with empty strings substituted for whitespace) directly to the model,
    /// or the model needs to implement a CNColumnMapper method that returns a dictionary of column mappings.
    /// </summary>
    /// <typeparam name="T">Alliance, Nation, War, or ForeignAid</typeparam>
    class FileParser<T> : IEnumerable<T> where T : CNBase, new()
    {
        readonly string[] _headers;
        readonly List<string> _lines;

        public FileParser(string fileName)
        {
            Contract.Requires(!string.IsNullOrEmpty(fileName));
            using (var file = new FileStream(fileName, FileMode.Open))
            using (var stream = new StreamReader(file))
            {
                _lines = new List<string>();
             
                _headers = stream.ReadLine().Split(new[] {'|'});
                while (!stream.EndOfStream)
                {
                    _lines.Add(stream.ReadLine());
                }             
            }
        }

        public FileParser(string [] lines)
        {
            _headers = lines[0].Split(new[] { '|' });
            _lines = lines.Skip(1).ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var entry in _lines)
            {
                T temp = new T();
                var columns = entry.Split(new[] { '|' });
                for (var i = 0; i < columns.Length; i++ )  
                {
                    if (string.IsNullOrEmpty(_headers[i])) continue;
                    string propertyName = TranslateProperty(_headers[i].Replace(" ", String.Empty));
                    PropertyInfo pTarget = temp.GetType().GetProperty(propertyName);
                    if (pTarget.PropertyType != typeof(string))
                    {
                        columns[i] = columns[i].Replace(",", string.Empty);
                        MethodInfo m = pTarget.PropertyType.UnderlyingSystemType.GetMethod("Parse", new [] { typeof(string) });
                        pTarget.SetValue(temp, m.Invoke(null, new object[] { columns[i] }));
                    }
                    else
                    {
                        pTarget.SetValue(temp, columns[i]);
                    }
                }
                yield return temp;
            }
        }

        private string TranslateProperty(string column)
        {
            T temp = new T();
            var mapper = temp.CNColumnMapper();
            if (mapper != null)
            {
                if (mapper.ContainsKey(column))
                {
                    return mapper[column];
                }
            }
            return column;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
