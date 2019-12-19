using Newtonsoft.Json;
using Sudoku.GameModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku.Repository
{
    public class Repository
    {
        private const string _sessions = "../../../../Sudoku/Data/sessions.json";
        private const string _records = "../../../../Sudoku/Data/records.json";

        private List<Session> sessions = new List<Session>() ;
        private List<Record> records = new List<Record>();

        public Repository()
        {
            StartTheGame();
        }

        public void BindRecords(List<Record> list)
        {
            list = records;
        }

        public decimal AverageTime()
        {
            decimal time = sessions.Average(x => x.TotalTimeMinutes);
            return time;
        }

        public void CloseGame(Session session)
        {
            sessions.Add(session);
            session.Ended = DateTime.Now;
            session.TotalTimeMinutes = (decimal)session.Ended.Value.Subtract(session.Started).TotalMinutes;
            SaveData<Session>(sessions, _sessions);
        }

        public bool BestSessionCheck(Session session)
        {
            var sessiontocheck = sessions.FirstOrDefault(x => x.TotalTimeMinutes > session.TotalTimeMinutes);
            if (sessiontocheck == null) return true;
            else return false;
        }

        public void Record(string Name, Session session)
        {
            records.Add(new Record()
            {
                SessionId = session.SessionId,
                Started = session.Started,
                Ended = session.Ended,
                TotalTimeMinutes = session.TotalTimeMinutes,
                GamerName = Name
            });

            while (records.Count > 15)
            {
                records.RemoveAt(0);
            }

            SaveData<Record>(records, _records);
        }


        public void StartTheGame()
        {
            RestoreData<Session>(sessions, _sessions);
            RestoreData<Record>(records, _records);
        }





        private void SaveData<T>(List<T> collection, string path)
        {
            var serializedData = JsonConvert.SerializeObject(collection);
            using (var sw = new StreamWriter(path))
            {
                sw.Write(serializedData);
            }
        }

        private void RestoreData<T>(List<T> collection, string path)
        {
            using (var sr = new StreamReader(path))
            {
                var data = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<T>>(data);

                collection.AddRange(list);
            }
        }
    }
}
