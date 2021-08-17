//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MongoDB.Driver;
//using TickClock.Models;

//namespace TickClock.Services
//{
//    public class SubmissionService
//    {
//        private readonly IMongoCollection<Submission> _submissions;

//        public SubmissionService(IDatabaseSettings settings)
//        {
//            var client = new MongoClient(settings.ConnectionString);
//            var database = client.GetDatabase(settings.DatabaseName);
//            _submissions = database.GetCollection<Submission>("Submissions");
//        }

//        public Submission Create(Submission submission)
//        {
//            _submissions.InsertOne(submission);
//            return submission;
//        }

//        public IList<Submission> Read() =>
//            _submissions.Find(sub => true).ToList();

//        public Submission Find(string id) =>
//            _submissions.Find(sub => sub.Id == id).SingleOrDefault();

//        public void Update(Submission submission) =>
//            _submissions.ReplaceOne(sub => sub.Id == submission.Id, submission);

//        public void Delete(string id) =>
//            _submissions.DeleteOne(sub => sub.Id == id);
//    }
//}
