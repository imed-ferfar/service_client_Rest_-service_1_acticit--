using ServeurActivite_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Web;
using System.Windows.Forms;

namespace ServeurActivite_Rest.Utils
{
    public class TraitementDemande
    {
        public static Demande GenererDemande(Demande maDemande)
        {
            int Annee = maDemande.Year;
            string message;
            if (Annee < 1970)
            {
                message = "Il est temps d’aller se promener à travers le monde";
            }
            else if (Annee <= 1980)
            {
                message = "Il est temps de commencer à travailler sérieusement";
            }
            else if (Annee <= 1990)
            {
                message = "Il est grand temps de terminer tes études";
            }
            else if (Annee <= 2000)
            {
                message = "Fais ce qui te plait, tu as encore le temps!";
            }
            else if (Annee <= 2010)
            {
                message = "Utilisation de ce service non-autorisée !!!";
            }
            else
                message = "Quelle école primaire fréquentes-tu ? :) !!!";

            maDemande.Message = message;
           /* MessageBox.Show("OK : "+message,
                    "Echéc de connexion!", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
            SauvgarderDemande(maDemande);
                    


            return maDemande;

        }



        public static int SauvgarderDemande(Demande dem)
        {
            int reslt = -1;
            try
            {
                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri("http://localhost:62954/api/");
                    //HTTP GET
                    var responseTask = client2.PostAsJsonAsync("demande", dem);
                    responseTask.Wait();

                    var resultat = responseTask.Result;

                    if (resultat.IsSuccessStatusCode)
                    {
                        /*var readTask = resultat.Content.ReadAsAsync<Demande>();
                        readTask.Wait();
                        var retour = readTask.Result;*/

                        // reslt = retour;
                        Console.WriteLine("Success");
                        /* MessageBox.Show("Success : ",
                             "Echéc de connexion!", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                    }
                    else
                        Console.WriteLine("Error");
                }
            } catch (AggregateException ex)
            {
                //Demandes en attentes ...
                /*try
                  {
                      if (ProviderListeDemandes.GetListDemandes().Count > 0)
                      {
                          client.SauvgarderListeEnAttente(ProviderListeDemandes.GetListDemandes().ToArray());
                          ProviderListeDemandes.ViderListing();

                          Console.WriteLine("La liste d'attente a été bien enregidtrée, " + ProviderListeDemandes.GetListDemandes().Count);
                      }
                      client.SauvgarderBdd(demSql);
                  }
                  catch (EndpointNotFoundException ex)
                  {
                      Console.WriteLine("Problème de connexion au serveur DAO !!!\n" + ex.Message);


                      //ajout demande à la liste d'attente
                    //  ProviderListeDemandes.AjouterDemande(demSql);
                      Console.WriteLine("Nombre de demandes en attente dans la liste temporaire  : " +
                          ProviderListeDemandes.GetListDemandes().Count);

                  }
                  catch (FaultException ex)
                  {
                      Console.WriteLine("Problème de connexion au serveur DAO !!!\n" + ex.Message);
                  }*/

            }

            return reslt;
         
        }
    }
}