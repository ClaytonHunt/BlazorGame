using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlazorGame.Framework
{
    public class LaunchParameters : Dictionary<string, string>, IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IDictionary, ICollection, IReadOnlyDictionary<string, string>, IReadOnlyCollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable, ISerializable, IDeserializationCallback
    {

    }
}
