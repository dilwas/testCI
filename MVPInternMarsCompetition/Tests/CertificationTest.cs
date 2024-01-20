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
    public class CertificationTest : BaseClass
    {
        CertificationPage certificationPageObj = new CertificationPage();

        public static string text = File.ReadAllText(@"Data\Certifications.json");
        public static JArray certificationsArray = JArray.Parse(text);

        IList<Certifications> certifications = certificationsArray.Select(p => new Certifications
        {
            Certificate = (string)p["Certificate"],
            From = (string)p["From"],
            Year = (string)p["Year"]
        }).ToList();
        
        [Test]
        public void AddANewCertificationRecord()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");
        }

        [Test]
        public void AddMultipleCertificationRecords()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);
            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            certificationPageObj.AddCertification(certifications[1].Certificate, certifications[1].From, certifications[1].Year);
            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[1].Certificate + " has been added to your certification", "certification has not been added");
            certificationPageObj.AddCertification(certifications[2].Certificate, certifications[2].From, certifications[2].Year);
            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[2].Certificate + " has been added to your certification", "certification has not been added");

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            Assert.That(certificationPageObj.CertificateLbl2.Text, Is.EqualTo(certifications[1].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl2.Text, Is.EqualTo(certifications[1].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl2.Text, Is.EqualTo(certifications[1].Year), "Year has not been added");

            Assert.That(certificationPageObj.CertificateLbl3.Text, Is.EqualTo(certifications[2].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl3.Text, Is.EqualTo(certifications[2].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl3.Text, Is.EqualTo(certifications[2].Year), "Year has not been added");
        }

        [Test]
        public void AddCertificationRecordWithSpecialCharacters()
        {
            certificationPageObj.AddCertification(certifications[3].Certificate, certifications[3].From, certifications[3].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[3].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[3].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[3].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[3].Year), "Year has not been added");
        }

        [Test]
        public void AddCertificationRecordWith100Characters()
        {
            certificationPageObj.AddCertification(certifications[4].Certificate, certifications[4].From, certifications[4].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[4].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[4].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[4].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[4].Year), "Year has not been added");
        }

        [Test]
        public void AddNewCertificationForSameFromAndYear()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.AddCertification(certifications[5].Certificate, certifications[5].From, certifications[5].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[5].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl2.Text, Is.EqualTo(certifications[5].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl2.Text, Is.EqualTo(certifications[5].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl2.Text, Is.EqualTo(certifications[5].Year), "Year has not been added");
        }

        [Test]
        public void CancelAddingNewCertification()
        {
            certificationPageObj.CancelAddingCertificationRecord();
            Assert.That(certificationPageObj.AddNewFields.Count == 0, "Add new record fields are still appeared");
        }

        [Test]
        public void EditExsistingRecordByChangingCertificate()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.EditCertificationSingleField(certifications[1].Certificate, "Certificate");

            Thread.Sleep(2000);
            Assert.AreEqual(certifications[1].Certificate + " has been updated to your certification", certificationPageObj.PopUpMsg.Text, "certification has not been added");
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[1].Certificate + " has been updated to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[1].Certificate), "Certificate has not been updated");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has been updated");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingFrom()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.EditCertificationSingleField(certifications[1].From, "From");

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been updated to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has been updated");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[1].From), "From has been updated");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has been updated");
        }

        [Test]
        public void EditExsistingRecordByChangingYear()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.EditCertificationSingleField(certifications[1].Year, "Year");

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been updated to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has been updated");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been updated");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[1].Year), "Year has been updated");
        }

        [Test]
        public void EditExistingCertificationRecordByChangingAllFields()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.EditCertificationRecord(certifications[1].Certificate, certifications[1].From, certifications[1].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[1].Certificate + " has been updated to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[1].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[1].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[1].Year), "Year has not been added");
        }

        [Test]
        public void DeleteCertificationRecord()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.DeleteCertificationRecord();
            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been deleted from your certification", "certification has not been added");
            Console.WriteLine(certificationPageObj.CertificationRecords.Count.ToString());
            Assert.That(certificationPageObj.CertificationRecords.Count == 0, "Certification record is still appeared");
        }

        [Test]
        public void AddNewCertificationRecordWithoutCertificate()
        {
            certificationPageObj.AddNewCertificationRecordWithoutRequirdFeilds(null, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certification has been added");
        }

        [Test]
        public void AddNewCertificationRecordWithoutFrom()
        {
            certificationPageObj.AddNewCertificationRecordWithoutRequirdFeilds(certifications[0].Certificate, null, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certification has been added");
        }

        [Test]
        public void AddNewCertificationRecordWithoutYear()
        {
            certificationPageObj.AddNewCertificationRecordWithoutRequirdFeilds(certifications[0].Certificate, certifications[0].From, null);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certification has been added");
        }

        [Test]
        public void AddNewCertificationRecordWithoutAllFeilds()
        {
            certificationPageObj.AddNewCertificationRecordWithoutRequirdFeilds(null, null, null);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certification has been added");
        }

        [Test]
        public void AddExistingNewCertificationRecord()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "This information is already exist.", "education has been added");
        }

        [Test]
        public void EditExistingCertificationRecordWithoutCahangingAnyFields()
        {
            certificationPageObj.AddCertification(certifications[0].Certificate, certifications[0].From, certifications[0].Year);

            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == certifications[0].Certificate + " has been added to your certification", "certification has not been added");
            Assert.That(certificationPageObj.CertificateLbl.Text, Is.EqualTo(certifications[0].Certificate), "Certificate has not been added");
            Assert.That(certificationPageObj.FromLbl.Text, Is.EqualTo(certifications[0].From), "From has not been added");
            Assert.That(certificationPageObj.YearLbl.Text, Is.EqualTo(certifications[0].Year), "Year has not been added");

            certificationPageObj.EditExistingCertificationRecordWithOutChangingAnyFields();
            Thread.Sleep(2000);
            Assert.That(certificationPageObj.PopUpMsg.Text == "This information is already exist.", "education has been added");
        }
    }
}
