using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.FormExtensions.Models;
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
                    City = GetFieldValueByName($"TM{i}_City", formSubmitContext.Fields),
                    State = GetFieldValueByName($"TM{i}_State", formSubmitContext.Fields),
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
                    foreach (var teamMember in teamMembers)
                    {
                        var source = "Hackathon.Signup.Form";
                        var id = $"{teamMember.Email.ToLower()}";
                        
                        var trackerIdentifier = new IdentifiedContactReference(source, id);
                        var expandOptions = new ContactExpandOptions(
                            CollectionModel.FacetKeys.PersonalInformation,
                            CollectionModel.FacetKeys.EmailAddressList);

                        Contact contact = client.Get(trackerIdentifier, expandOptions);

                        SetPersonalInformation(teamMember.FirstName, teamMember.LastName, contact, client);
                        SetLocationInformation(teamMember.City, teamMember.State, teamMember.Country, contact, client);
                        SetEmail(teamMember.Email, contact, client);

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