using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models // add first data to the database
{
    public class ContextDbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
          /* db.Services.Add(new Serv { Name = "Annonser", Description = "Har du behov for profilannonser, trafikkskapende annonser eller en stillingsannonse, står vi parat.", ServiceImage = "im/image.jpg", Price = 2000 });
            db.Services.Add(new Serv { Name = "Brosjyrer", Description = "Trykt materiell lever fremdeles i beste velgående. Skam for den som trodde noe annet. Noen påstår at ingenting er som en rykende fersk brosjyre du kan sitte og bla i, i ro og mak. Du har full oversikt med det samme, ingen forsinkelser", ServiceImage = "im/image.jpg", Price = 1000 });
            db.Services.Add(new Serv { Name = "Markedsplan", Description = "En markedsplan er et godt arbeidsverktøy med beskrivelse av hva du skal gjøre fremover,hvorfor,hvordan,når og med hvilken ønsket effekt.", ServiceImage = "im / image.jpg", Price = 10000 });

    */

            db.Projects.Add(new Project { Customer = "Nortrain", ProjectDescription = "Tele2 Norge AS har 55 medarbeidere og omsatte i 2008 for 2,99 milliarder NOK. Selskapet ledes av administrerende direktør Arild Hustad. Tele2 Norge er en del av Tele2 AB, et pan-europeisk telekomselskap med cirka 25 millioner kunder i 11 europeiske land, med en omsetning i 2008 på 39,5 milliarder SEK.",Price = 2000, Date = new DateTime(2010, 11, 18) });
            db.Projects.Add(new Project { Customer = "SAS", ProjectDescription = "er et skandinavisk flyselskap som driver multinasjonalt i de tre skandinaviske landene Norge, Sverige og Danmark, og fungerer som nasjonalflyselskap for disse landene.[5]", Price = 2000, Date = new DateTime(2014, 10, 12) });
            db.Projects.Add(new Project { Customer = "Statoil", ProjectDescription = "Har du behov for profilannonser, trafikkskapende annonser eller en stillingsannonse, står vi parat.", Price = 2000, Date = new DateTime(2015, 08, 19) });
            db.Projects.Add(new Project { Customer = "Tele2", ProjectDescription = "Statoil Fuel & Retail AS er et selskap som selger petroleumsprodukter. Selskapet ble skilt ut fra Statoil i 2010 og kjøpt opp av det canadiske selskapet Alimentation Couche-Tard i 2012", Price = 2000, Date = new DateTime(2015, 02, 02) });

            db.ProjectCategories.Add(new ProjectCategory { Name = "Markedsplan" });
            db.ProjectCategories.Add(new ProjectCategory { Name = "Brosjyrer" });
            db.ProjectCategories.Add(new ProjectCategory { Name = "Annonser" });

            base.Seed(db);
            
        }
    }
    
}