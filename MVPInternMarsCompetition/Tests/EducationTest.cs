using MVPInternMarsCompetition.Data;
using MVPInternMarsCompetition.Pages;
using MVPInternMarsCompetition.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVPInternMarsCompetition.Tests
{
    [TestFixture]
    public class EducationTest : BaseClass
    {
        EducationPage educationPageObj = new EducationPage();

        public static string text = File.ReadAllText(@"Data\Educations.json");
        public static JArray educationsArray = JArray.Parse(text);

        IList<Educations> educations = educationsArray.Select(p => new Educations
        {
            University = (string)p["University"],
            Country = (string)p["Country"],
            Title = (string)p["Title"],
            Degree = (string)p["Degree"],
            YearOfGraduation = (string)p["YearOfGraduation"]
        }).ToList();
        
        [Test]
        public void AddANewEducationRecord()
        {
            educationPageObj.AddEducation(educations[0].University,educations[0].Country,educations[0].Title,educations[0].YearOfGraduation,educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");  
        }

        [Test]
        public void AddMultipleEducationRecords()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);
            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            educationPageObj.AddEducation(educations[1].University, educations[1].Country, educations[1].Title, educations[1].YearOfGraduation, educations[1].Degree);
            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            educationPageObj.AddEducation(educations[2].University, educations[2].Country, educations[2].Title, educations[2].YearOfGraduation, educations[2].Degree);
            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            Assert.That(educationPageObj.UniversityNameLbl2.Text, Is.EqualTo(educations[1].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl2.Text, Is.EqualTo(educations[1].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl2.Text, Is.EqualTo(educations[1].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl2.Text, Is.EqualTo(educations[1].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl2.Text, Is.EqualTo(educations[1].Degree), "Degree has not been added");

            Assert.That(educationPageObj.UniversityNameLbl3.Text, Is.EqualTo(educations[2].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl3.Text, Is.EqualTo(educations[2].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl3.Text, Is.EqualTo(educations[2].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl3.Text, Is.EqualTo(educations[2].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl3.Text, Is.EqualTo(educations[2].Degree), "Degree has not been added");
        }

        [Test]
        public void AddEducationRecordWithSpecialCharacters()
        {
            educationPageObj.AddEducation(educations[3].University, educations[3].Country, educations[3].Title, educations[3].YearOfGraduation, educations[3].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[3].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[3].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[3].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[3].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[3].Degree), "Degree has not been added");
        }

        [Test]
        public void AddEducationRecordWith100Characters()
        {
            educationPageObj.AddEducation(educations[4].University, educations[4].Country, educations[4].Title, educations[4].YearOfGraduation, educations[4].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[4].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[4].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[4].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[4].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[4].Degree), "Degree has not been added");
        }

        [Test]
        public void AddNewEducationForSameCountryUniversityYear()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.AddEducation(educations[5].University, educations[5].Country, educations[5].Title, educations[5].YearOfGraduation, educations[5].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl2.Text, Is.EqualTo(educations[5].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl2.Text, Is.EqualTo(educations[5].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl2.Text, Is.EqualTo(educations[5].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl2.Text, Is.EqualTo(educations[5].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl2.Text, Is.EqualTo(educations[5].Degree), "Degree has not been added");
        }

        [Test]
        public void CancelAddingNewEducation()
        {
            educationPageObj.CancelAddingEducationRecord();
            Assert.That(educationPageObj.AddNewFields.Count == 0, "Add new record fields are still appeared");
        }

        [Test]
        public void EditExsistingRecordByChangingUniversity()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationSingleField(educations[1].University, "University");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[1].University), "University has not been updated");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has been updated");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has been updated");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has been updated");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingCountry()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationSingleField(educations[1].Country, "Country");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has been updated");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[1].Country), "Country has not been updated");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has been updated");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has been updated");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingTitle()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationSingleField(educations[1].Title, "Title");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has been updated");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has been updated");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[1].Title), "Title has not been updated");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has been updated");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingYear()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationSingleField(educations[1].YearOfGraduation, "YearOfGraduation");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has been updated");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has been updated");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has been updated");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[1].YearOfGraduation), "Year of graduation has not been updated");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingDegree()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationSingleField(educations[1].Degree, "Degree");

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has been updated");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has been updated");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has been updated");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has been updated");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[1].Degree), "Degree has not been updated");
        }

        [Test]
        public void EditExistingEducationRecordByChangingAllFields()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditEducationRecord(educations[1].University, educations[1].Country, educations[1].Title, educations[1].YearOfGraduation, educations[1].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[1].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[1].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[1].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[1].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[1].Degree), "Degree has not been added");
        }

        [Test]
        public void DeleteEducationRecord()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.DeleteEducationRecord();
            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education entry successfully removed", "Education entry not removed");
            Console.WriteLine(educationPageObj.EducationRecords.Count.ToString());
            Assert.That(educationPageObj.EducationRecords.Count == 0, "Education record is still appeared");
        }

        [Test]
        public void AddNewEducationRecordWithoutUniversity()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(null, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddNewEducationRecordWithoutCountry()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].University, null, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddNewEducationRecordWithoutTitle()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].University, educations[0].Country, null, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddNewEducationRecordWithoutYear()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].University, educations[0].Country, educations[0].Title, null, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddNewEducationRecordWithoutDegree()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, null);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddNewEducationRecordWithoutAllFeilds()
        {
            educationPageObj.AddNewEducationRecordWithoutRequirdFeilds(null, null, null, null, null);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
        }

        [Test]
        public void AddExistingNewEducationRecord()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "This information is already exist.", "education has been added");
        }

        [Test]
        public void EditExistingEducationRecordWithoutCahangingAnyFields()
        {
            educationPageObj.AddEducation(educations[0].University, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            Assert.That(educationPageObj.UniversityNameLbl.Text, Is.EqualTo(educations[0].University), "University has not been added");
            Assert.That(educationPageObj.CountryLbl.Text, Is.EqualTo(educations[0].Country), "Country has not been added");
            Assert.That(educationPageObj.TitleLbl.Text, Is.EqualTo(educations[0].Title), "Title has not been added");
            Assert.That(educationPageObj.YearLbl.Text, Is.EqualTo(educations[0].YearOfGraduation), "Year of graduation has not been added");
            Assert.That(educationPageObj.DegreeLbl.Text, Is.EqualTo(educations[0].Degree), "Degree has not been added");

            educationPageObj.EditExistingEducationRecordWithOutChangingAnyFields();
            Thread.Sleep(2000);
            Assert.That(educationPageObj.PopUpMsg.Text == "This information is already exist.", "education has been added");

        }
    }
}
