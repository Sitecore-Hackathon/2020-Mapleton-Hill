using Glass.Mapper.Sc.Fields;
using Hackathon.Feature.Navigation.Menu;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;

namespace Hackathon.Feature.Navigation.Models
{
    public class MenuModel 
    {
        public string TemplateId { get; set; }

        public Guid Id { get; set; }

        public Link Link { get; set; }

        public List<MenuModel> Items { get; set; }

        public Language Language { get; set; }

        public int Version { get; set; }
    }
}