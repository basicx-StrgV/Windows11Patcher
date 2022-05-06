using Windows11Patcher.Runtime;

namespace Windows11Patcher
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new RuntimeBuilder().Build(args).Run();
        }
    }
}
