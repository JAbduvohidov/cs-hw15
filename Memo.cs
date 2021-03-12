namespace _15
{
    public class Memo
    {
        public int MemoId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}