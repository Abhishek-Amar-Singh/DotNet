using Microsoft.AspNetCore.Mvc;
using System.Collections.Frozen;

namespace CSharp.Web.Api.Services
{
    public interface IProductService
    {
        IEnumerable<string> Random_Yield();
        IEnumerable<string> RandomShuffle();
        FrozenDictionary<int, string> FrozenDictCollection();
        FrozenSet<int> FrozenSetCollection();
        IDictionary<string, dynamic> JsonNodeExample();
        bool MinStatementNull();
        dynamic SpreadOperator();
    }
}
