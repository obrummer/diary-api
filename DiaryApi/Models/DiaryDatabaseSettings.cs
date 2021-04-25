using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaryApi.Models
{
    public class DiaryDatabaseSettings : IDiaryDatabaseSettings
    {
        public string DiaryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDiaryDatabaseSettings
    {
        string DiaryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
