using System.Text;

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

        public string PatternVA(int n)
        {
            int cn = n;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            while (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    sb.Append("*");
                }
                int a = cn - n;//how many spaces?
                n = n - 2;
                for (int j= 1; j <= a; j++)
                {
                    sb.Append(" ");
                    sb.Insert(0, " ");
                }
                sb.Append("\\n");
                sb2.Append(sb);
                sb.Clear();
            }
            string result = sb2.ToString();

            return result;
        }
    }
}
