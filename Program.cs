namespace _15
{
    internal static class Program
    {
        private static void Main()
        {
            //1
            using var db = new TodoCtx();
            var todoRepo = new TodoRepository(db);

            var blog = new Todo {Title = "Todo"};
            todoRepo.Create(blog);

            blog = todoRepo.Read(blog.TodoId);

            blog.Title = "Todo1";
            blog.Memos.Add(new Memo {Title = "Memo1", Body = "Memo1 B o d y"});
            todoRepo.Update();

            blog = todoRepo.Read(blog.TodoId);

            todoRepo.Delete(blog);
        }
    }
}