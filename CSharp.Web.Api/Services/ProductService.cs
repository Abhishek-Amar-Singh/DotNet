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
    }
}
