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
    //private List<float> data = new List<float>() { };
    //public List<float> Data { get { return data; } }
    private List<string> categories = new List<string>() { };
    public List<string> Categories { get { return categories; } }

    private List<float> data = new List<float>() { };
    public List<float> Data { get { return data; } }

    private Dictionary<string, List<float>> series = new Dictionary<string, List<float>>() { };
    public Dictionary<string, List<float>> Series { get { return series; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = this.Request_Json();
        this.ParseJson(json);
    }
    private string Request_Json()
    {
        string result = null;
        string url = "https://www.lbcit.ca/demo/api";
        string keyVal = "d9658b9d-4f86-491f-bd67-86af0c547a5c";
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
        foreach (var itemObj in categoriesArr)
        {
            categories.Add(itemObj.ToString());
        }
        foreach (JObject itemObj in seriesArr)
        {
            //data.Add(itemObj["name"].ToString());
            JArray dataArr = JArray.Parse(itemObj["data"].ToString());
            foreach (var dataEle in dataArr)
            {
                //series.Add(itemObj["name"].ToString(), dataEle);
                data.Add(float.Parse(dataEle.ToString()));
            }
            series.Add(itemObj["name"].ToString(), data);
            //JArray dataArr = JArray.Parse(obj["data"].ToString());
            //data.Add(float.Parse(itemObj["data"].ToString()));
            //series.Add(itemObj["name"].ToString());
            //JArray dataArr = JArray.Parse(itemObj["data"].ToString());
            //foreach (var ele in dataArr)
            //{
            //    issue.Done = ele.ToString();
            //}
            //issue.Author = itemObj["author"]["name"].ToString();
            //issues.Add(issue);
        }

        //IssueListView.ItemsSource = issues;
    }
}