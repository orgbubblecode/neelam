using Newtonsoft.Json;
using OrgBubbleDataViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OBSync.Models.Helpers
{
    public class OrgBubbleViewsHelper
    {





    }

    [Serializable]
    public class OrgBubblePost_data_json
    {
        //public string media { get; set; } = "";
        public List<string> media { get; set; } = new List<string>();

        public string caption { get; set; } = "";

        public string link { get; set; } = "";

        public string comment { get; set; } = "";

        public string url { get; set; } = "";

        public string location { get; set; } = "";

        public string story_friends { get; set; } = "";

        public string repeat { get; set; } = "";

        public string repeat_end { get; set; } = "";

    }



        public class OrgBubblePost_data
        {

        public OrgBubblePost_data_json data_json { get; set; }


        [JsonIgnore]
        public bool Casted { get; set; } = false;

        [JsonIgnore]
        public string TextMessage { get; set; } = "";

        [JsonIgnore]
        public string HTML { get; set; } = "";

        public OrgBubblePost_data(orgbubble_socialmedia_posts oPost)
        {
            // string strData = 

            try
            {
                OrgBubblePost_data_json oData = JsonConvert.DeserializeObject<OrgBubblePost_data_json>(oPost.data.Replace(@"\", ""));

                if(oData!=null)
                {
                    this.data_json = oData;

                    this.Casted = true;
                    this.TextMessage = JsonHelper.FormatJson(oPost.data.Replace(@"\", ""));

                }
                else
                {



                    this.TextMessage = JsonHelper.FormatJson(oPost.data.Replace(@"\", ""));
                    this.Casted = false;

                }



                this.HTML = "<h3>Data:</h3> <ul>" +

                     "<li>media: " + this.data_json?.media ?? Models.Helpers.Utilities.ListOfLinksToHTMLList(this.data_json.media) + "   </li>" +
                     "<li>caption: " + this.data_json?.caption ?? "" + "  </li>" +
                     "<li>link: " + this.data_json?.link ?? "" + "  </li>" +
                     "<li>url: " + this.data_json?.url ?? "" + "  </li>" +
                     "<li>location: " + this.data_json?.location ?? "" + "  </li>" +
                     "<li>story_friends: " + this.data_json?.story_friends ?? "" + "  </li>" +
                     "<li>repeat: " + this.data_json?.repeat ?? "" + "  </li>" +
                     "<li>repeat_end: " + this.data_json?.repeat_end ?? "" + "  </li> </ul>";




            }
            catch (Exception ex)
            {

                this.HTML = "<h3>Data:</h3> <ul>" +

                 "<li>media: " + this.data_json?.media ?? Models.Helpers.Utilities.ListOfLinksToHTMLList(this.data_json.media) + "   </li>" +
                 "<li>caption: " + this.data_json?.caption ?? "" + "  </li>" +
                 "<li>link: " + this.data_json?.link ?? "" + "  </li>" +
                 "<li>url: " + this.data_json?.url ?? "" + "  </li>" +
                 "<li>location: " + this.data_json?.location ?? "" + "  </li>" +
                 "<li>story_friends: " + this.data_json?.story_friends ?? "" + "  </li>" +
                 "<li>repeat: " + this.data_json?.repeat ?? "" + "  </li>" +
                 "<li>repeat_end: " + this.data_json?.repeat_end ?? "" + "  </li>" +

             "</ul>";

                this.TextMessage = oPost.data.Replace(@"\", "");
                this.Casted = false;

             
            }
                       

        }


    }


    public class OrgBubblePost_result_json
    {
        public string message { get; set; } = "";

        public string id { get; set; } = "";

        public string url { get; set; } = "";

    }


        public class OrgBubblePost_result
    {
        public OrgBubblePost_result_json result_json { get; set; }

        [JsonIgnore]
        public string HTML { get; set; } = "";

        [JsonIgnore]
        public bool Casted { get; set; } = false;

        [JsonIgnore]
        public string TextMessage { get; set; } = "";

        public OrgBubblePost_result(orgbubble_socialmedia_posts oPost)
        {



            try
            {
                OrgBubblePost_result_json oData = JsonConvert.DeserializeObject<OrgBubblePost_result_json>(oPost.result.Replace(@"\",""));

                if (oData != null)
                {
                    this.result_json = oData;
                                             

                    this.Casted = true;
                    this.TextMessage = JsonHelper.FormatJson(oPost.result);


                }
                else
                {



                    this.TextMessage = JsonHelper.FormatJson(oPost.result);
                    this.Casted = false;

                }




                this.HTML = "<h3>Result:</h3> <ul>" +

                     "<li>message: " + this.result_json?.message ?? "" + "   </li>" +
                     "<li>id: " + this.result_json?.id ?? "" + "  </li>" +
                     "<li>url: " + this.result_json?.url ?? "" + "  </li></ul>";

                this.TextMessage = JsonHelper.FormatJson(oPost.data.Replace(@"\", ""));
                this.Casted = false;


            }
            catch (Exception ex)
            {

                //this.message = oPost.result;
                this.HTML = "<h3>Result:</h3> <ul>" +

                    "<li>message: " + oPost.result ?? "" + "   </li>" +
                    "<li>id: - </li>" +
                    "<li>url:- </li></ul>";

                this.TextMessage = oPost.result?.Replace(@"\", "");
                this.Casted = false;

              
            }










        }

    }


    public class OrgBubblePost_response
    {


        public OrgBubblePost_data data { get; set; }// = new OrgBubblePost_data();

        public OrgBubblePost_result result { get; set; }// = new OrgBubblePost_result();

        [JsonIgnore]
        public string HTML { get; set; } = "";

        [JsonIgnore]
        public bool Casted { get; set; } = false;

        [JsonIgnore]
        public string TextMessage { get; set; } = "";

        public OrgBubblePost_response(orgbubble_socialmedia_posts oPost)
        {
            if (oPost!=null)
            {
                this.data = new OrgBubblePost_data(oPost);
                this.result = new OrgBubblePost_result(oPost);
                this.HTML = string.Concat(this.result.HTML, " </br> </br>", this.data.HTML);
                this.TextMessage = JsonHelper.FormatJson(oPost.result?.Replace(@"\", "")) + Environment.NewLine + Environment.NewLine + JsonHelper.FormatJson(oPost.data.Replace(@"\", ""));
            }

          
        }



    }
}