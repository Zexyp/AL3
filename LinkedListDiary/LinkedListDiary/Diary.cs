using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

using CrossEngine.Serialization.Json;

namespace LinkedListDiary
{
    class Diary
    {
        public DiaryPage CurrentPage => _current?.Value;

        private readonly LinkedList<DiaryPage> Pages = new LinkedList<DiaryPage>();
        private LinkedListNode<DiaryPage> _current = null;
        private JsonSerializer _serializer = new JsonSerializer(JsonSerializerSettings.CreateDefault());

        public DiaryPage[] GetPages() => Pages.ToArray();
        public void AddPage(DiaryPage page)
        {
            Pages.AddLast(page);
            if (Pages.Count == 1)
                _current = Pages.First;
        }
        public void InsertPage(DiaryPage page)
        {
            if (Pages.Count == 0)
            {
                AddPage(page);
                return;
            }

            Pages.AddAfter(_current, page);
        }
        public void DropPage()
        {
            var next = _current.Next;
            Pages.Remove(_current);
            _current = next ?? Pages.Last;
        }
        //public void AddPageBefore(DiaryPage before, DiaryPage page) => Pages.AddBefore(Pages.Find(before), page);
        //public void AddPageAfter(DiaryPage before, DiaryPage page) => Pages.AddAfter(Pages.Find(before), page);
        public bool Next()
        {
            if (_current?.Next == null)
                return false;
            _current = _current?.Next;
            return true;
        }
        public bool Previous()
        {
            if (_current?.Previous == null)
                return false;
            _current = _current?.Previous;
            return true;
        }

        public void Save(string path)
        {
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
            {
                _serializer.Serialize(Pages.ToArray(), fs);
            }
        }

        public bool Load(string path)
        {
            Debug.Assert(Pages.Count == 0);

            if (!File.Exists(path))
                return false;

            DiaryPage[] loadedpages;
            using (FileStream fs = File.OpenRead(path))
            {
                loadedpages = (DiaryPage[])_serializer.Deserialize(fs, typeof(DiaryPage[]));
            }

            foreach (var page in loadedpages)
            {
                InsertPage(page);
                Next();
            }

            return true;
        }
    }
}
