using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.FormExtensions.Models;
using Sitecore.Analytics;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Sitecore.XConnect.Collection.Model;

namespace Hackathon.Feature.FormExtensions.SubmitActions
{
    /// <summary>
    /// Submit action for updating <see cref="PersonalInformation"/> and <see cref="EmailAddressList"/> facets of a <see cref="XConnect.Contact"/>.
    /// </summary>
    /// <seealso cref="Sitecore.ExperienceForms.Processing.Actions.SubmitActionBase{TeamFormData}" />
    public class AddTeamContacts : SubmitActionBase<TeamFormData>
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
        protected override bool Execute(TeamFormData data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(data, nameof(data));
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            var teamMembers = new TeamMember[3] {
                new TeamMember {
                    TeamName = GetFieldById(data.TeamNameFieldId, formSubmitContext.Fields),
                    Email = GetFieldById(data.TeamMemberOneEmailFieldId, formSubmitContext.Fields),
                    Twitter = GetFieldById(data.TeamMemberOneTwitterFieldId, formSubmitContext.Fields),
                    LinkedIn = GetFieldById(data.TeamMemberOneLinkedInFieldId, formSubmitContext.Fields),
                    FirstName = GetFieldById(data.TeamMemberOneFirstNameFieldId, formSubmitContext.Fields),
                    LastName = GetFieldById(data.TeamMemberOneLastNameFieldId, formSubmitContext.Fields),
                    City = GetFieldById(data.TeamMemberOneCityFieldId, formSubmitContext.Fields),
                    State = GetFieldById(data.TeamMemberOneStateFieldId, formSubmitContext.Fields),
                    Country = GetFieldById(data.TeamMemberOneCountryFieldId, formSubmitContext.Fields)
                },
                new TeamMember {
                    TeamName = GetFieldById(data.TeamNameFieldId, formSubmitContext.Fields),
                    Email = GetFieldById(data.TeamMemberTwoEmailFieldId, formSubmitContext.Fields),
                    Twitter = GetFieldById(data.TeamMemberTwoTwitterFieldId, formSubmitContext.Fields),
                    LinkedIn = GetFieldById(data.TeamMemberTwoLinkedInFieldId, formSubmitContext.Fields),
                    FirstName = GetFieldById(data.TeamMemberTwoFirstNameFieldId, formSubmitContext.Fields),
                    LastName = GetFieldById(data.TeamMemberTwoLastNameFieldId, formSubmitContext.Fields),
                    City = GetFieldById(data.TeamMemberTwoCityFieldId, formSubmitContext.Fields),
                    State = GetFieldById(data.TeamMemberTwoStateFieldId, formSubmitContext.Fields),
                    Country = GetFieldById(data.TeamMemberTwoCountryFieldId, formSubmitContext.Fields)
                },
                new TeamMember {
                    TeamName = GetFieldById(data.TeamNameFieldId, formSubmitContext.Fields),
                    Email = GetFieldById(data.TeamMemberThreeEmailFieldId, formSubmitContext.Fields),
                    Twitter = GetFieldById(data.TeamMemberThreeTwitterFieldId, formSubmitContext.Fields),
                    LinkedIn = GetFieldById(data.TeamMemberThreeLinkedInFieldId, formSubmitContext.Fields),
                    FirstName = GetFieldById(data.TeamMemberThreeFirstNameFieldId, formSubmitContext.Fields),
                    LastName = GetFieldById(data.TeamMemberThreeLastNameFieldId, formSubmitContext.Fields),
                    City = GetFieldById(data.TeamMemberThreeCityFieldId, formSubmitContext.Fields),
                    State = GetFieldById(data.TeamMemberThreeStateFieldId, formSubmitContext.Fields),
                    Country = GetFieldById(data.TeamMemberThreeCountryFieldId, formSubmitContext.Fields)
                }
            };

            if (teamMembers.All(tm => GetValue(tm.Email) == null))
            {
                return false;
            }

            using (var client = CreateClient())
            {
                try
                {
                    foreach (var teamMember in teamMembers)
                    {
                        var source = "Hackathon.Signup.Form";
                        var id = $"{GetValue(teamMember.Email).ToLower()}";
                        
                        var trackerIdentifier = new IdentifiedContactReference(source, id);
                        var expandOptions = new ContactExpandOptions(
                            CollectionModel.FacetKeys.PersonalInformation,
                            CollectionModel.FacetKeys.EmailAddressList);

                        Contact contact = client.Get(trackerIdentifier, expandOptions);

                        SetPersonalInformation(GetValue(teamMember.FirstName), GetValue(teamMember.LastName), contact, client);
                        SetLocationInformation(GetValue(teamMember.City), GetValue(teamMember.State), GetValue(teamMember.Country), contact, client);
                        SetEmail(GetValue(teamMember.Email), contact, client);

                        client.Submit();
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
        /// <returns>The field with the specified <paramref name="id" />.</returns>
        private static IViewModel GetFieldById(Guid id, IList<IViewModel> fields)
        {
            return fields.FirstOrDefault(f => Guid.Parse(f.ItemId) == id);
        }

        /// <summary>
        /// Gets the <paramref name="field" /> value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>The field value.</returns>
        private static string GetValue(object field)
        {
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
        /// Sets the <see cref="AddressList"/> facet of the specified <paramref name="contact" />.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="contact"></param>
        /// <param name="client"></param>
        private static void SetLocationInformation(string city, string state, string country, Contact contact, IXdbContext client)
        {
            if (string.IsNullOrEmpty(country))
            {
                return;
            }


            Address address = new Address
            {
                City = city,
                StateOrProvince = state,
                CountryCode = country
            };
            AddressList addressFacet = contact.Addresses();
            if (addressFacet == null)
            {
                

                addressFacet = new AddressList(address, "Preferred");
            }
            else
            {
                if (addressFacet.PreferredAddress?.CountryCode == country)
                {
                    return;
                }

                addressFacet.PreferredAddress = address;
            }

            client.SetAddresses(contact, addressFacet);
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