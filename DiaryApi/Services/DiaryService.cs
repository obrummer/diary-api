using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaryApi.Models;

namespace DiaryApi.Services
{
    public class DiaryService
    {
        private readonly IMongoCollection<DiaryEvent> _diaryEvents;

        public DiaryService(IDiaryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _diaryEvents = database.GetCollection<DiaryEvent>(settings.DiaryCollectionName);
        }

        public List<DiaryEvent> Get() =>
            _diaryEvents.Find(diary => true).ToList();

        public DiaryEvent Get(string id) =>
            _diaryEvents.Find<DiaryEvent>(diary => diary.Id == id).FirstOrDefault();

        public DiaryEvent Create(DiaryEvent diaryEvent)
        {
            _diaryEvents.InsertOne(diaryEvent);
            return diaryEvent;
        }

        public void Update(string id, DiaryEvent eventIn) =>
            _diaryEvents.ReplaceOne(diary => diary.Id == id, eventIn);

        public void Remove(DiaryEvent eventIn) =>
            _diaryEvents.DeleteOne(diary => diary.Id == eventIn.Id);

        public void Remove(string id) =>
            _diaryEvents.DeleteOne(diary => diary.Id == id);
    }
}
