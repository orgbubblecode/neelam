using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using NameParser;


namespace OBSync.Models.Helpers
{
    public class Utilities
    {

        public static HumanName NameObject(string FullName)
        {

            var oName = new HumanName(FullName);
            return oName;

        }



        public static string ListOfLinksToHTMLList(List<string> List)
        {

           if (List!=null && List.Count>0)
            {

                string strHTML = "<ul>";

                foreach (string link in List)
                    {
                    strHTML = strHTML + "<li><a href='##link##' target='_blank'>##link##</a></li>".Replace("##link##", link);
                }

                strHTML = strHTML + "<ul>";

                return strHTML;

            }
           else
            {
                return "";
            }


        }



        public static bool IsVideo(string FilePath)
        {
            try
            {
                NReco.VideoInfo.FFProbe ffProbe = new NReco.VideoInfo.FFProbe();
                NReco.VideoInfo.MediaInfo videoInfo = ffProbe.GetMediaInfo(FilePath);

                if (videoInfo.Duration.Seconds > 0)
                { return true; }
                else
                { return false; }

            }

            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool IsImage(string Url)
        {
            try
            {

          
            var client = new WebClient();
            var content = client.DownloadData(Url);
            var stream = new MemoryStream(content);

            return IsImage(stream);

            }
            catch (Exception)
            {

                return false;
               
            }

        }


        public static bool IsImage(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            List<string> jpg = new List<string>()
    {
        "FF",
        "D8"
    };
            List<string> bmp = new List<string>()
    {
        "42",
        "4D"
    };
            List<string> gif = new List<string>()
    {
        "47",
        "49",
        "46"
    };
            List<string> png = new List<string>()
    {
        "89",
        "50",
        "4E",
        "47",
        "0D",
        "0A",
        "1A",
        "0A"
    };
            List<List<string>> imgTypes = new List<List<string>>()
    {
        jpg,
        bmp,
        gif,
        png
    };

            List<string> bytesIterated = new List<string>();

            for (int i = 0; i <= 7; i++)
            {
                string bit = stream.ReadByte().ToString("X2");
                bytesIterated.Add(bit);

                bool isImage__1 = imgTypes.Any(img => !img.Except(bytesIterated).Any());
                if (isImage__1)
                    return true;
            }

            return false;
        }




    }




    class JsonHelper
    {
        private const string INDENT_STRING = "    ";
        public static string FormatJson(string str)
        {

            if (str == null)
                return "";


            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }




}