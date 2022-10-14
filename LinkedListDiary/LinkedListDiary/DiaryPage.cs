using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrossEngine.Serialization;

namespace LinkedListDiary
{
    class DiaryPage : ISerializable
    {
        public DateTime Date;
        public string Text;

        public DiaryPage()
        {
        }

        public DiaryPage(DateTime date, string text)
        {
            Date = date;
            Text = text;
        }

        public void GetObjectData(SerializationInfo info)
        {
            info.AddValue(nameof(Date), Date);
            info.AddValue(nameof(Text), Text);
        }

        public void SetObjectData(SerializationInfo info)
        {
            Date = info.GetValue(nameof(Date), Date);
            Text = info.GetValue(nameof(Text), Text);
        }
    }
}
