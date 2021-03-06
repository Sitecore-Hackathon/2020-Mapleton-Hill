
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


namespace Hackathon.Feature.Media
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
    ///[RepresentsSitecoreTemplateAttribute("{d6ecc2ed-3755-4621-8e99-5a5f6b081ba7}", "", "Feature.Media")]
    [SitecoreType(TemplateId = Hackathon.Feature.Media.Constants.Dummy.TemplateIdString)]
	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public partial interface IDummy : IGlassBase
    {
        
        /// <summary>Represents the Description field (8258052b-b8d4-4206-9117-34d2708d6ab9).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Media.Constants.Dummy.Fields.Description_FieldName)]
        string Description { get; }

        /// <summary>Represents the Title field (7e14cf7d-bcee-45cf-adb9-a0723fc6e30f).</summary>
        [SitecoreField(FieldName = Hackathon.Feature.Media.Constants.Dummy.Fields.Title_FieldName)]
        string Title { get; }

    }

}

namespace Hackathon.Feature.Media.Constants
{
    using global::Sitecore.Data;
	using System.CodeDom.Compiler;

	[GeneratedCode("Leprechaun", "1.0.0.0")]
    public struct Dummy
    {
        public const string TemplateIdString = "d6ecc2ed-3755-4621-8e99-5a5f6b081ba7";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        
        public struct Fields
        {
        public static readonly ID Description = new ID("8258052b-b8d4-4206-9117-34d2708d6ab9");
        public const string Description_FieldName = "Description";

        public static readonly ID Title = new ID("7e14cf7d-bcee-45cf-adb9-a0723fc6e30f");
        public const string Title_FieldName = "Title";

        }
    }
}




namespace Hackathon.Feature.Media
{
	using global::Sitecore.Data;

	public struct Templates
	{
		
		public struct Dummy
		{
            public const string TemplateIdString = "d6ecc2ed-3755-4621-8e99-5a5f6b081ba7";
			public static readonly ID TemplateId = new ID(TemplateIdString);

			
			public struct Fields
			{
				public static readonly ID Description = new ID("8258052b-b8d4-4206-9117-34d2708d6ab9");
				public const string Description_FieldName = "Description";

				public static readonly ID Title = new ID("7e14cf7d-bcee-45cf-adb9-a0723fc6e30f");
				public const string Title_FieldName = "Title";

			}
		}

	}
}

// Hackathon.Feature.Media.Dummy (/sitecore/templates/Feature/Media/Dummy d6ecc2ed-3755-4621-8e99-5a5f6b081ba7)
	// Description (8258052b-b8d4-4206-9117-34d2708d6ab9)
		// Type: Multi-Line Text
		// Section: Basic Information
		// Sort Order: 200
		// Source: 
	// Title (7e14cf7d-bcee-45cf-adb9-a0723fc6e30f)
		// Type: Single-Line Text
		// Section: Basic Information
		// Sort Order: 100
		// Source: 

