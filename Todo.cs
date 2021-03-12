using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _15
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public int Done { get; set; }
        public List<Memo> Memos { get; set; }
    }

    public class TodoCtx : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Memo> Memos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=user;Password=pass;Database=hw15db");
        }
    }

    class TodoRepository
    {
        private readonly TodoCtx _db;

        public TodoRepository(TodoCtx db)
        {
            _db = db;
        }

        public void Create(Todo todo)
        {
            _db.Add(todo);
            _db.SaveChanges();
        }

        public Todo Read(int todoId)
        {
            return _db.Todos
                .Include(b => b.Memos)
                .Single(b => b.TodoId == todoId);
        }

        public void Update()
        {
            _db.SaveChanges();
        }

        public void Delete(Todo todo)
        {
            _db.Remove(todo);
            _db.SaveChanges();
        }
    }
}