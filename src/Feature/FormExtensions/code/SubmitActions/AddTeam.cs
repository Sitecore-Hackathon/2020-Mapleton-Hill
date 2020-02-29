using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using System;

namespace Hackathon.Feature.FormExtensions.SubmitActions
{
    public class AddTeam : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateContact"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public AddTeam(ISubmitActionData submitActionData) : base(submitActionData)
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

            // get team names from Sitecore context db for current year
            Database db = Sitecore.Configuration.Factory.GetDatabase("master");
            var teamTemplate = db.GetTemplate(SitecoreConstants.TeamTemplateId);
            var currentTeamFolder = db.GetItem($"/sitecore/content/data/hackathons/hackathon {DateTime.Now.Year}/teams");

            // if name not found, add it
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    Item newItem = currentTeamFolder.Add(teamName, teamTemplate);
                    if (newItem != null)
                    {
                        newItem.Editing.BeginEdit();
                        newItem[Sitecore.FieldIDs.DisplayName] = teamName;
                        newItem.Editing.EndEdit();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex, this);
                    return false;
                }
            }

            return true;
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
    }
}