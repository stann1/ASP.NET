using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalStats
{
    public partial class GlobalStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddContinent_Click(object sender, EventArgs e)
        {
            this.LabelResponse.Text = "";
            this.ButtonConfirmEdit.Visible = false;
            this.TextBoxAddContinent.Visible = true;
            this.ButtonConfirmAdding.Visible = true;
            
        }

        protected void ButtonEditContinent_Click(object sender, EventArgs e)
        {
            this.LabelResponse.Text = "";
            this.ButtonConfirmAdding.Visible = false;
            this.TextBoxAddContinent.Visible = true;           
            this.ButtonConfirmEdit.Visible = true;
        }

        protected void ButtonDeleteContinent_Click(object sender, EventArgs e)
        {
            this.LabelResponse.Text = "";
            AddressBookEntities context = new AddressBookEntities();
            int selectedContinent = int.Parse(this.ListBoxContinents.SelectedValue);

            var existingCont = context.Continents.FirstOrDefault(c => c.ContinentId == selectedContinent);
            context.Continents.Remove(existingCont);
            context.SaveChanges();
            this.LabelResponse.Text = "Continent removed.";
            this.ListBoxContinents.DataBind();
        }

        protected void CreateContinent(object sender, EventArgs e)
        {
            AddressBookEntities context = new AddressBookEntities();
            string continent = this.TextBoxAddContinent.Text;
            if (string.IsNullOrEmpty(continent))
            {                
                this.LabelResponse.Text = "Error: Continent name cannot be empty!"; 
            }
            else
            {
                context.Continents.Add(new Continent() { Name = continent });
                context.SaveChanges();
                this.LabelResponse.Text = "Continent added";
                this.ListBoxContinents.DataBind();
            }
                        
            this.TextBoxAddContinent.Visible = false;
            this.ButtonConfirmAdding.Visible = false;
        }

        protected void EditContinentName(object sender, EventArgs e)
        {
            AddressBookEntities context = new AddressBookEntities();
            string newContinentName = this.TextBoxAddContinent.Text;
            if (string.IsNullOrEmpty(newContinentName))
            {
                this.LabelResponse.Text = "Error: Continent name cannot be empty!";               
            }
            else
            {
                int selectedContinent = int.Parse(this.ListBoxContinents.SelectedValue);
                var existingCont = context.Continents.FirstOrDefault(c => c.ContinentId == selectedContinent);
                existingCont.Name = newContinentName;
                context.SaveChanges();
                this.LabelResponse.Text = "Continent name changed";
                this.ListBoxContinents.DataBind();
            }
            
            this.TextBoxAddContinent.Visible = false;
            this.ButtonConfirmEdit.Visible = false;
        }

        protected void ButtonShowAddCountry_Click(object sender, EventArgs e)
        {
            this.addCountry.Visible = true;            
        }

        protected void CreateCountry(object sender, EventArgs e)
        {
            AddressBookEntities context = new AddressBookEntities();
            string countryName = this.TextBoxAddCountryName.Text;
            string countryLang = this.TextBoxAddCountryLang.Text;
            string countryPopulation = this.TextBoxAddCountryPop.Text;

            //validate inputs
            if (string.IsNullOrEmpty(countryName) || string.IsNullOrEmpty(countryLang) || string.IsNullOrEmpty(countryPopulation) )
            {
                this.LabelAddCountryResponse.Text = "Error: country data-fields cannot be empty!";
                return;
            }            

            //check if country exists
            var existingCountry = context.Countries.FirstOrDefault(c => c.Name == countryName);
            if (existingCountry != null)
            {
                this.LabelAddCountryResponse.Text = "Error: a country with this name already exists!";
                return;
            }

            int continentIndex = int.Parse(this.ListBoxContinents.SelectedValue);

            context.Countries.Add(new Country() 
                { Name = countryName, Language = countryLang, Population = int.Parse(countryPopulation), ContinentId = continentIndex }
            );
            context.SaveChanges();
            this.LabelAddCountryResponse.Text = "Country added.";
            this.addCountry.Visible = false;
            this.GridViewCountries.DataBind();
        }

        protected void ButtonCancelAdding_Click(object sender, EventArgs e)
        {
            this.addCountry.Visible = false;
        }
    }
}