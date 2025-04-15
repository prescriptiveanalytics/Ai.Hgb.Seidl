namespace Ai.Hgb.Application.Common
{
    public class Properties
    {
        public static int DocCount;
        public static string DocPrefix;
    }

    public struct Document
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public float Value { get; set; }
    }

}
