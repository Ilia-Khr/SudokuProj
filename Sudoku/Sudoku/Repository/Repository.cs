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

        public List<Record> GetSortedRecords()
            => records.OrderByDescending(value => value.TotalTime)
            .ToList();


        public string AverageTime()
        {
            var time = sessions.Average(x => x.TotalTime);
            int seconds = (int) time / 1;
            var result = GetTimeToShow(seconds);
            return result;
        }
           
        private string GetTimeToShow(int time)
        {
            var hours = time / 360;
            var minutes = time / 60;
            var seconds = time % 60;
            string min;
            string sec;
            string h;
            if (minutes < 10)
            {
                min = "0" + minutes.ToString();
            }
            else 
            {
                min = minutes.ToString();
            }
            if (seconds < 10)
            {
               sec = "0" + seconds.ToString().Substring(0,1);
            }
            else
            {
                sec = seconds.ToString().Substring(0,2);
            }
            if (hours < 10)
            {
                h = "0" + hours.ToString();
            }
            else
            {
                h = hours.ToString();
            }
            return h +':'+min + ':' + sec;

        }
        

        public void CloseGame(Session session)
        {
            session.Ended = DateTime.Now;
            var time = (int)session.Ended.Value.Subtract(session.Started).TotalSeconds;
            
            session.TotalTime = time;
            session.ToShow = GetTimeToShow(time);
            
        }

        public void Add(Session session)
        {
            sessions.Add(session);
            SaveData<Session>(sessions, _sessions);
        }

        public bool BestSessionCheck(decimal time) => 
            time < sessions.Min(x => x.TotalTime);


        public void Record(string Name, Session session)
        {
            records.Add(new Record()
            {
                SessionId = session.SessionId,
                Started = session.Started,
                Ended = session.Ended,
                TotalTime = session.TotalTime,
                ToShow= session.ToShow,
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
