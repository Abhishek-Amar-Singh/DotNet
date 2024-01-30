namespace CSharp.Web.Api.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<string> Random_Yield()
        {
            string[] musicians =
            {
                "Lucky Ali",
                "Mohit Chauhan",
                "Jagjit Singh",
                "Vishal Mishra",
                "Abhijit Sawant",
                "Arijit Singh",
                "Atif Aslam",
                "Kishore Kumar",
                "Papon"
            };

            for (int i = 0; i < 5; i++)
            {
                string[] choices =
                    Random.Shared.GetItems(musicians, 2);

                yield return string.Join(",", choices);
            }
        }

        public IEnumerable<string> RandomShuffle()
        {
            string[] musicians =
            {
                "Lucky Ali",
                "Mohit Chauhan",
                "Jagjit Singh",
                "Vishal Mishra",
                "Abhijit Sawant",
                "Arijit Singh",
                "Atif Aslam",
                "Kishore Kumar",
                "Papon"
            };

            Random.Shared.Shuffle(musicians);

            return musicians;
        }

        public FrozenDictionary<int, string> FrozenDictCollection()
        {
            var frozenDict = new Dictionary<int, string>()
            {
                {2001, "The Fast and the Furious" },
                {2003, "2 Fast 2 Furious" },
                {2006, "The Fast and the Furious: Tokyo Drift" },
                {2009, "Fast & Furious" },
                {2011, "Fast Five" },
                {2013, "Fast & Furious 6" },
                {2015, "Furious 7" },
                {2017, "The Fate of the Furious" },
                {2021, "F9" },
                {2023, "Fast X"}
            }.ToFrozenDictionary();

            return frozenDict;
        }

        public FrozenSet<int> FrozenSetCollection()
        {
            var frozenSet = new List<int>() { 1,2,3,4,5}.ToFrozenSet();

            return frozenSet;
        }

        public IDictionary<string, dynamic> JsonNodeExample()
        {
            var json = """
                {
                "name": "DotNet Core",
                "version": [3.1, 5, 6, 7, 8],
                "language": "C#"
                }
                """;

            JsonNode? node = JsonNode.Parse(json);
            JsonNode other = node!.DeepClone();
            var flag = JsonNode.DeepEquals(node, other);

            JsonArray jsonArray = new JsonArray(1,2,5,4,7,8);
            IEnumerable<int> values = jsonArray.GetValues<int>().Where(i => i%2==0);

            return new Dictionary<string, dynamic>
            {
                { "DeepEquals O/P", flag},
                { "jsonArray O/P", values }
            };

        }

        public record ClassA();
        public bool MinStatementNull()
        {
            ClassA a = null;

            if (a is null) a = new();

            a = a is null ? new() : a;

            a = a ?? new();

            a ??= new();

            return true;
        }

        public dynamic SpreadOperator()
        {
            int[] a = [1, 2, 3];
            int[] b = [4, 5, 6];

            //1st way
            int[] e = new int[a.Length + b.Length];
            a.CopyTo(e, 0);
            b.CopyTo(e, 0);

            //2nd way
            int[] f = [];
            f = a.ToArray().Concat(b).ToArray();

            //3rd way
            int[] d = [.. a, .. b];

            return new
            {
                one = e,
                two = f,
                three = d
            };

        }
    }
}
