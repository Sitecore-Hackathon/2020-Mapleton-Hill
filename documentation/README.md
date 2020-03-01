# Sitecore-Driven Hackathon Website

## Summary

**Category:** Sitecore Hackathon Website

Every year requires teams to sign-up for the hackathon and being able to flexibly manage that content.  The rebuild of the Hackathon Website was built with taking advantage of the best features of the Experience Plaform such as Sitecore Forms integration, integrated teams listing component and integration of participants into xDB.  The goal was to start a foundation to build a stronger experience for the hackathon participants.

## Pre-requisites

The solution depends on the following:

- Sitecore 9.3 Initial Release
- Sitecore Forms
- xDB must be enabled

Before installing the website, the following changes will need to be made under the Visual Studio solution:

1. Update the source folder under src\Foundation\Serialization\code\App_Config\Include\zzz\z.DevSettings.config to where the project has been setup on the machine.
2. Create a publishsettings.targets.user file and update the publishUrl to the URL Sitecore 9.3 is setup.

## Installation

Deploying the new Hackathon Website requires publishing the various projects in Visual Studio as listed below:

1. Hackathon.Foundation.Serialization
2. Hackathon.Foundation.DependencyInjection
3. Hackathon.Foundation.DataAccess
4. Hackathon.Feature.FormExtensions
5. Hackathon.Feature.Media
6. Hackathon.Feature.Navigation
7. Hackathon.Feature.Newsletter
8. Hackathon.Feature.SharedComponents
9. Hackathon.Feature.Signup
10. Hackathon.Feature.Teams
11. SitecoreHackathon.Website

## Usage

The site was built with the following components:

1. Teams Listing Component

![Teams Listing Component](images/teams-listing.png?raw=true "Teams Listing Component")

2. Hackathons, Teams and Participates can be managed from Sitecore

![Content Tree](images/content-tree.png?raw=true "Content Tree")