
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// ReSharper disable All


namespace Hackathon.Feature.Navigation.Footer
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Hackathon.Foundation.DataAccess.Models;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

    /// <summary>Controls the appearance of the inheriting template in site navigation.</summary>
    ///[RepresentsSitecoreTemplateAttribute("{b7187448-7fc7-49d2-90e0-554ca84480a8}", "", "Feature.Navigation")]
    [SitecoreType(TemplateId = Hackathon.Feature.Navigation.Footer.Constants.Footer.TemplateIdString)]
	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public partial interface IFooter : IGlassBase
    {
        
        /// <summary>Represents the Menu field (dcebab75-c016-49ce-ac6a-20c70380d861).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Footer.Constants.Footer.Fields.Menu_FieldName)]
        Guid Menu { get; }

        /// <summary>Represents the Title field (bebe2d98-d088-43ae-8c77-c44289765437).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Footer.Constants.Footer.Fields.Title_FieldName)]
        string Title { get; }

    }

}

namespace Hackathon.Feature.Navigation.Footer.Constants
{
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public struct Footer
    {
        public const string TemplateIdString = "b7187448-7fc7-49d2-90e0-554ca84480a8";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        
        public struct Fields
        {
        public static readonly ID Menu = new ID("dcebab75-c016-49ce-ac6a-20c70380d861");
        public const string Menu_FieldName = "Menu";

        public static readonly ID Title = new ID("bebe2d98-d088-43ae-8c77-c44289765437");
        public const string Title_FieldName = "Title";

        }
    }
}

namespace Hackathon.Feature.Navigation.Header
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Hackathon.Foundation.DataAccess.Models;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

    /// <summary>Controls the appearance of the inheriting template in site navigation.</summary>
    ///[RepresentsSitecoreTemplateAttribute("{0da298d0-6f13-4434-8b2d-85e13fb4fc8b}", "", "Feature.Navigation")]
    [SitecoreType(TemplateId = Hackathon.Feature.Navigation.Header.Constants.Header.TemplateIdString)]
	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public partial interface IHeader : IGlassBase
    {
        
        /// <summary>Represents the Image field (5220f431-0d31-41f4-bb5a-0dd7197f5a81).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Header.Constants.Header.Fields.Image_FieldName)]
        Image Image { get; }

        /// <summary>Represents the Menu field (c756c89c-f905-4255-b1e8-275a38f655a6).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Header.Constants.Header.Fields.Menu_FieldName)]
        Guid Menu { get; }

    }

}

namespace Hackathon.Feature.Navigation.Header.Constants
{
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public struct Header
    {
        public const string TemplateIdString = "0da298d0-6f13-4434-8b2d-85e13fb4fc8b";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        
        public struct Fields
        {
        public static readonly ID Image = new ID("5220f431-0d31-41f4-bb5a-0dd7197f5a81");
        public const string Image_FieldName = "Image";

        public static readonly ID Menu = new ID("c756c89c-f905-4255-b1e8-275a38f655a6");
        public const string Menu_FieldName = "Menu";

        }
    }
}

namespace Hackathon.Feature.Navigation.Menu
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Hackathon.Foundation.DataAccess.Models;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

    /// <summary>Controls the appearance of the inheriting template in site navigation.</summary>
    ///[RepresentsSitecoreTemplateAttribute("{4482f966-bb9b-4e00-ab75-098e918b2380}", "", "Feature.Navigation")]
    [SitecoreType(TemplateId = Hackathon.Feature.Navigation.Menu.Constants.Menu.TemplateIdString)]
	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public partial interface IMenu : IGlassBase
    {
        
        /// <summary>Represents the Items field (231def93-f0d6-45f9-a007-f1091f85e904).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Menu.Constants.Menu.Fields.Items_FieldName)]
        IEnumerable<Guid> Items { get; }

        /// <summary>Represents the Link field (3084a512-8d35-428f-af99-b23b6000c389).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Navigation.Menu.Constants.Menu.Fields.Link_FieldName)]
        Link Link { get; }

    }

}

namespace Hackathon.Feature.Navigation.Menu.Constants
{
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public struct Menu
    {
        public const string TemplateIdString = "4482f966-bb9b-4e00-ab75-098e918b2380";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        
        public struct Fields
        {
        public static readonly ID Items = new ID("231def93-f0d6-45f9-a007-f1091f85e904");
        public const string Items_FieldName = "Items";

        public static readonly ID Link = new ID("3084a512-8d35-428f-af99-b23b6000c389");
        public const string Link_FieldName = "Link";

        }
    }
}

namespace Hackathon.Feature.Navigation
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Hackathon.Foundation.DataAccess.Models;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

    /// <summary>Controls the appearance of the inheriting template in site navigation.</summary>
    ///[RepresentsSitecoreTemplateAttribute("{0ebeffc7-4211-4586-9adc-05eade438a0c}", "", "Feature.Navigation")]
    [SitecoreType(TemplateId = Hackathon.Feature.Navigation.Constants.NavigationFolder.TemplateIdString)]
	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public partial interface INavigationFolder : IGlassBase
    {
        
    }

}

namespace Hackathon.Feature.Navigation.Constants
{
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public struct NavigationFolder
    {
        public const string TemplateIdString = "0ebeffc7-4211-4586-9adc-05eade438a0c";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        
    }
}




namespace Hackathon.Feature.Navigation
{
	using global::Sitecore.Data;

	public struct Templates
	{
		
		public struct Footer
		{
            public const string TemplateIdString = "b7187448-7fc7-49d2-90e0-554ca84480a8";
			public static readonly ID TemplateId = new ID(TemplateIdString);

			
			public struct Fields
			{
				public static readonly ID Menu = new ID("dcebab75-c016-49ce-ac6a-20c70380d861");
				public const string Menu_FieldName = "Menu";

				public static readonly ID Title = new ID("bebe2d98-d088-43ae-8c77-c44289765437");
				public const string Title_FieldName = "Title";

			}
		}

		public struct Header
		{
            public const string TemplateIdString = "0da298d0-6f13-4434-8b2d-85e13fb4fc8b";
			public static readonly ID TemplateId = new ID(TemplateIdString);

			
			public struct Fields
			{
				public static readonly ID Image = new ID("5220f431-0d31-41f4-bb5a-0dd7197f5a81");
				public const string Image_FieldName = "Image";

				public static readonly ID Menu = new ID("c756c89c-f905-4255-b1e8-275a38f655a6");
				public const string Menu_FieldName = "Menu";

			}
		}

		public struct Menu
		{
            public const string TemplateIdString = "4482f966-bb9b-4e00-ab75-098e918b2380";
			public static readonly ID TemplateId = new ID(TemplateIdString);

			
			public struct Fields
			{
				public static readonly ID Items = new ID("231def93-f0d6-45f9-a007-f1091f85e904");
				public const string Items_FieldName = "Items";

				public static readonly ID Link = new ID("3084a512-8d35-428f-af99-b23b6000c389");
				public const string Link_FieldName = "Link";

			}
		}

		public struct NavigationFolder
		{
            public const string TemplateIdString = "0ebeffc7-4211-4586-9adc-05eade438a0c";
			public static readonly ID TemplateId = new ID(TemplateIdString);

			
		}

	}
}

// Hackathon.Feature.Navigation.Footer.Footer (/sitecore/templates/Feature/Navigation/Footer/Footer b7187448-7fc7-49d2-90e0-554ca84480a8)
	// Menu (dcebab75-c016-49ce-ac6a-20c70380d861)
		// Type: Droplink
		// Section: Data
		// Sort Order: 200
		// Source: query:./*[@@templateid='{BD4F960A-D498-4C3D-83F4-D1F9CF85C34F}' or @@templateid='{1CEEE23D-52BF-450A-91F0-70CE3E6F5E71}']
	// Title (bebe2d98-d088-43ae-8c77-c44289765437)
		// Type: Single-Line Text
		// Section: Data
		// Sort Order: 100
		// Source: 

// Hackathon.Feature.Navigation.Header.Header (/sitecore/templates/Feature/Navigation/Header/Header 0da298d0-6f13-4434-8b2d-85e13fb4fc8b)
	// Image (5220f431-0d31-41f4-bb5a-0dd7197f5a81)
		// Type: Image
		// Section: Data
		// Sort Order: 100
		// Source: /sitecore/media library/Images
	// Menu (c756c89c-f905-4255-b1e8-275a38f655a6)
		// Type: Droplink
		// Section: Data
		// Sort Order: 200
		// Source: query:./*[@@templateid='{BD4F960A-D498-4C3D-83F4-D1F9CF85C34F}' or @@templateid='{1CEEE23D-52BF-450A-91F0-70CE3E6F5E71}']

// Hackathon.Feature.Navigation.Menu.Menu (/sitecore/templates/Feature/Navigation/Menu/Menu 4482f966-bb9b-4e00-ab75-098e918b2380)
	// Items (231def93-f0d6-45f9-a007-f1091f85e904)
		// Type: Multilist
		// Section: Data
		// Sort Order: 200
		// Source: query:./*[@@templateid='{4482F966-BB9B-4E00-AB75-098E918B2380}']
	// Link (3084a512-8d35-428f-af99-b23b6000c389)
		// Type: General Link
		// Section: Data
		// Sort Order: 100
		// Source: 

// Hackathon.Feature.Navigation.NavigationFolder (/sitecore/templates/Feature/Navigation/Navigation Folder 0ebeffc7-4211-4586-9adc-05eade438a0c)

