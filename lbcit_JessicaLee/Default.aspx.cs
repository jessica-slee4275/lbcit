using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class _Default : System.Web.UI.Page
{
    private List<string> name = new List<string>() { };
    public List<string> Name { get { return name; } }

    private string [,] contentArr = new string[,] { };
    public string[,] ContentArr { get { return contentArr; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        string json = this.Request_Json();
        this.ParseJson(json);
    }
    private string Request_Json()
    {
        string result = null;
        string url = "https://www.lbcit.ca/demo/api";
        string keyVal = "";
        url = $"{url}/?key={keyVal}";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            result = reader.ReadToEnd();
            stream.Close();
            response.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }
    private void ParseJson(String json)
    {
        JObject obj = JObject.Parse(json);
        
        JArray categoriesArr = JArray.Parse(obj["categories"].ToString());
        JArray seriesArr = JArray.Parse(obj["series"].ToString());
        int index = 0;
        string[,] dataArrStr = new string[categoriesArr.Count, seriesArr.Count + 1];
        
        for (int j = 0; j < categoriesArr.Count; j++)
        {
            dataArrStr[j, index] = categoriesArr[j].ToString();
        }
        index++;
        foreach (JObject itemObj in seriesArr)
        {
            JArray dataArr = JArray.Parse(itemObj["data"].ToString());
            for (int j = 0; j < dataArr.Count; j++)
            {
                dataArrStr[j, index] = dataArr[j].ToString();
            }
            index++;
            contentArr = dataArrStr;
            name.Add(itemObj["name"].ToString());
        }
    }
    
}

