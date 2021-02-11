using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class Stream
    {
        public PublicUser oneUser { get; set; }

        public string imgPath { get; set; }
        public List<Blog> AllBlogs { get; set; }
        public static List<Stream> ScanStream(List<Stream> strm)
        {
            List<Stream> newStrm = new List<Stream>();
            for(int i = 0; i < strm.Count; i++)
            {
                if(strm[i].AllBlogs.Count!=0)
                {
                    newStrm.Add(strm[i]);
                }
            }
            return newStrm;
        }
    }
}
