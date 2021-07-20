using System;
using TickClock.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickClock.Services
{
    public class ClockService
    {
        private readonly IMongoCollection<TodoItem> _todoItems;

        public ClockService(ITickClockDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todoItems = database.GetCollection<TodoItem>(settings.TodosCollectionName);
        }

        public List<TodoItem> Get() =>
            _todoItems.Find(TodoItem => true).ToList();

        public TodoItem Get(string id) =>
            _todoItems.Find<TodoItem>(t => t.Id==id).FirstOrDefault();

        public TodoItem Create(TodoItem TodoItem)
        {
            _todoItems.InsertOne(TodoItem);
            return TodoItem;
        }

        public void Update(string id, TodoItem todoItem) =>
            _todoItems.ReplaceOne(t => t.Id == id, todoItem);

        public void Remove(TodoItem todoItem) =>
            _todoItems.DeleteOne(t => t.Id == todoItem.Id);

        public void Remove(string id) =>
            _todoItems.DeleteOne(t => t.Id == id);
    }
}
