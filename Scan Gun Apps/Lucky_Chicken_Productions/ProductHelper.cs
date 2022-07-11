using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Lucky_Chicken_Productions
{
    public class ProductHelper
    {
        public static string GetProductName(string tag)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.luckychickenproductions.com/api/tag?tag=" + tag);
                request.Method = "GET";
                request.KeepAlive = false;
                request.Timeout = 30000;
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                response.Close();
                return responseString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        public static bool SubmitTags(List<string> tags)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.luckychickenproductions.com/api/tags?tags=" + string.Join(",", tags.ToArray()));
                request.Method = "POST";
                request.KeepAlive = false;
                request.Timeout = 30000;
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                response.Close();
                if (responseString.ToLower().Equals("ok"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }         
        }        
    }
}
