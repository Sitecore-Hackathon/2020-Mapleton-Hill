using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.FormExtensions.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Sitecore.XConnect.Collection.Model;
using Sitecore.Analytics;

namespace Hackathon.Feature.FormExtensions.SubmitActions
{
    /// <summary>
    /// Submit action for updating <see cref="PersonalInformation"/> and <see cref="EmailAddressList"/> facets of a <see cref="XConnect.Contact"/>.
    /// </summary>
    /// <seealso cref="Sitecore.ExperienceForms.Processing.Actions.SubmitActionBase{TeamFormData}" />
    public class AddTeamContacts : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateContact"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public AddTeamContacts(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        /// <summary>
        /// Gets the current tracker.
        /// </summary>
        protected virtual ITracker CurrentTracker => Tracker.Current;

        /// <summary>
        /// Executes the action with the specified <paramref name="data" />.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="formSubmitContext">The form submit context.</param>
        /// <returns><c>true</c> if the action is executed correctly; otherwise <c>false</c></returns>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(data, nameof(data));
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            string teamName = GetFieldValueByName("TeamName", formSubmitContext.Fields);

            var teamMembers = new List<TeamMember>();
            int i = 1;
            while (!string.IsNullOrEmpty(GetFieldValueByName($"TM{i}_Email", formSubmitContext.Fields)))
            {
                teamMembers.Add(new TeamMember
                {
                    TeamName = teamName,
                    Email = GetFieldValueByName($"TM{i}_Email", formSubmitContext.Fields),
                    Twitter = GetFieldValueByName($"TM{i}_TwitterUrl", formSubmitContext.Fields),
                    LinkedIn = GetFieldValueByName($"TM{i}_LinkedInUrl", formSubmitContext.Fields),
                    FirstName = GetFieldValueByName($"TM{i}_FirstName", formSubmitContext.Fields),
                    LastName = GetFieldValueByName($"TM{i}_LastName", formSubmitContext.Fields),
                    Country = GetFieldValueByName($"TM{i}_Country", formSubmitContext.Fields),
                });

                i++;
            }

            if (!teamMembers.Any())
            {
                return false;
            }

            using (var client = CreateClient())
            {
                try
                {
                    Database db = Sitecore.Configuration.Factory.GetDatabase("master");
                    Guid teamId = CreateTeam(teamName, teamMembers, db);
                    foreach (var teamMember in teamMembers)
                    {
                        Contact contact = null;

                        //var source = "Hackathon.Signup";
                        //var identifier = CurrentTracker?.Contact.ContactId.ToString("N");

                        //CurrentTracker?.Session.IdentifyAs(source, identifier);

                        //var trackerIdentifier = new IdentifiedContactReference(source, identifier);
                        //var expandOptions = new ContactExpandOptions(
                        //    CollectionModel.FacetKeys.PersonalInformation,
                        //    CollectionModel.FacetKeys.EmailAddressList);

                        //contact = client.Get(trackerIdentifier, expandOptions);

                        //if (contact != null)
                        //{
                        //    SetPersonalInformation(teamMember.FirstName, teamMember.LastName, contact, client);
                        //    SetEmail(teamMember.Email, contact, client);

                        //    client.Submit();
                        //}

                        CreateTeamMember(teamMember, contact, db);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message, ex);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Create Member Item for current Team Member
        /// </summary>
        /// <param name="teamMember"></param>
        /// <param name="contact"></param>
        /// <param name="db"></param>
        private void CreateTeamMember(TeamMember teamMember, Contact contact, Database db)
        {
            var memberTemplate = db.GetTemplate(SitecoreConstants.MemberTemplateId);
            var participantsFolder = db.GetItem(SitecoreConstants.ParticipantsFolderId);

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                Item member = participantsFolder.Add($"{teamMember.FirstName} {teamMember.LastName}", memberTemplate);
                if (member != null)
                {
                    member.Editing.BeginEdit();
                    member["First Name"] = teamMember.FirstName;
                    member["Last Name"] = teamMember.LastName;
                    member["Email"] = teamMember.Email;
                    member["xDb Contact Id"] = contact?.Id.ToString();
                    member.Editing.EndEdit();

                    // create link folder
                    var linkFolderTemplate = db.GetTemplate(SitecoreConstants.LinkFolderTemplateId);
                    Item linkFolder = member.Add("Links", linkFolderTemplate);

                    if (!string.IsNullOrEmpty(teamMember.Twitter))
                    {
                        if (teamMember.Twitter.Contains("twitter.com") && IsUrlValid(teamMember.Twitter))
                        {
                            var linkTemplate = db.GetTemplate(SitecoreConstants.LinkTemplateId);
                            var twitterLink = linkFolder.Add("Twitter", linkTemplate);
                            twitterLink.Editing.BeginEdit();
                            twitterLink["Link"] = teamMember.Twitter;
                            twitterLink["Type"] = SitecoreConstants.TitterLinkId;
                            twitterLink.Editing.EndEdit();
                        }
                    }

                    if (!string.IsNullOrEmpty(teamMember.LinkedIn))
                    {
                        if (teamMember.LinkedIn.Contains("linkedin.com") && IsUrlValid(teamMember.LinkedIn))
                        {
                            var linkTemplate = db.GetTemplate(SitecoreConstants.LinkTemplateId);
                            var linkedInLink = linkFolder.Add("LinkedIn", linkTemplate);
                            linkedInLink.Editing.BeginEdit();
                            linkedInLink["Link"] = teamMember.Twitter;
                            linkedInLink["Type"] = SitecoreConstants.LinkedInLinkId;
                            linkedInLink.Editing.EndEdit();
                        }
                    }
                }
            }
        }

        private bool IsUrlValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Create a Team Item
        /// </summary>
        /// <param name="teamName"></param>
        /// <param name="teamMembers"></param>
        /// <param name="db"></param>
        /// <returns>Guid ID of new Team Item.</returns>
        private Guid CreateTeam(string teamName, IEnumerable<TeamMember> teamMembers, Database db)
        {
            var countries = teamMembers.Select(tm => tm.Country);
            var teamTemplate = db.GetTemplate(SitecoreConstants.TeamTemplateId);
            var currentTeamFolder = db.GetItem($"/sitecore/content/sitecore-hackathon/Data/Hackathons/Hackathon {DateTime.Now.Year}/Teams");

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                Item newItem = currentTeamFolder.Add(teamName, teamTemplate);
                if (newItem != null)
                {
                    newItem.Editing.BeginEdit();
                    newItem["Name"] = teamName;
                    newItem["Countries"] = string.Join("|", countries);
                    newItem.Editing.EndEdit();
                }

                return newItem.ID.ToGuid();
            }
        }

        // This is the problematic method which needs to be overriden
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <returns>The <see cref="IXdbContext"/> instance.</returns>
        protected virtual IXdbContext CreateClient()
        {
            return SitecoreXConnectClientConfiguration.GetClient();
        }

        /// <summary>
        /// Gets the field by <paramref name="id" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>The field value with the specified <paramref name="id" />.</returns>
        private static string GetFieldValueByName(string name, IList<IViewModel> fields)
        {
            var field = fields.FirstOrDefault(f => f.Name == name);
            return field?.GetType().GetProperty("Value")?.GetValue(field, null)?.ToString() ?? string.Empty;
        }
        
        /// <summary>
        /// Sets the <see cref="PersonalInformation"/> facet of the specified <paramref name="contact" />.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="contact">The contact.</param>
        /// <param name="client">The client.</param>
        private static void SetPersonalInformation(string firstName, string lastName, Contact contact, IXdbContext client)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return;
            }

            PersonalInformation personalInfoFacet = contact.Personal() ?? new PersonalInformation();
            if (personalInfoFacet.FirstName == firstName && personalInfoFacet.LastName == lastName)
            {
                return;
            }

            personalInfoFacet.FirstName = firstName;
            personalInfoFacet.LastName = lastName;

            client.SetPersonal(contact, personalInfoFacet);
        }

        /// <summary>
        /// Sets the <see cref="EmailAddressList"/> facet of the specified <paramref name="contact" />.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <param name="contact">The contact.</param>
        /// <param name="client">The client.</param>
        private static void SetEmail(string email, Contact contact, IXdbContext client)
        {
            if (string.IsNullOrEmpty(email))
            {
                return;
            }

            EmailAddressList emailFacet = contact.Emails();
            if (emailFacet == null)
            {
                emailFacet = new EmailAddressList(new EmailAddress(email, false), "Preferred");
            }
            else
            {
                if (emailFacet.PreferredEmail?.SmtpAddress == email)
                {
                    return;
                }

                emailFacet.PreferredEmail = new EmailAddress(email, false);
            }

            client.SetEmails(contact, emailFacet);
        }
    }
}