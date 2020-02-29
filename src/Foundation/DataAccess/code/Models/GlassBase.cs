using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Globalization;
using System;

namespace Hackathon.Foundation.DataAccess.Models
{
    public abstract partial class GlassBase : IGlassBase
    {
        [SitecoreId]
        public Guid Id { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        public Language Language { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public int Version { get; private set; }
    }
}