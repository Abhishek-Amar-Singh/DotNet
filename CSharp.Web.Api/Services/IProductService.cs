namespace CSharp.Web.Api.Services
{
    public interface IProductService
    {
        IEnumerable<string> Random_Yield();
        IEnumerable<string> RandomShuffle();
        string PatternVA(int n);
    }
}
