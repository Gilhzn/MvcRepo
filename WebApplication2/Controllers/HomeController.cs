using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string linkUrl = null) {
            List<FeedItem> model = new List<FeedItem>();
            if (linkUrl != null)
            {
                try
                {
                    model = ParseRssFile(linkUrl);
                }
                catch (Exception ex)
                {
                    ////Log

                }
            }

            return View(model);
        }


        public ActionResult GetRss(string linkUrl)
        {
            List<FeedItem> model = new List<FeedItem>();
            try
            {
                model = ParseRssFile(linkUrl);
            }
            catch (Exception ex)
            {
                ////Log

            }
            return PartialView("~/Views/Home/_RssView.cshtml", model);
        }


        private List<FeedItem> ParseRssFile(string linkUrl)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            rssXmlDoc.Load(linkUrl);

            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();
            List<FeedItem> itemsList = new List<FeedItem>();
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description").SelectSingleNode("img");
                string imageUrl = rssSubNode != null ? rssSubNode.InnerText : "";

                DateTime date;
                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string pubdate = rssSubNode != null ? rssSubNode.InnerText : "";
                string dateTime = DateTime.TryParse(pubdate, out date) ? date.ToString("yyyy-MM-dd HH:mm") : string.Empty;

                itemsList.Add(new FeedItem { Title = title, Link = link, Description = description, ImageUrl = imageUrl, Date = dateTime });
            }

            return itemsList;
        }
    }
}
