using ServeurActivite_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServeurActivite_Rest.Utils
{
    internal class ProviderListeDemandes
    {

        private static List<Demande> listing = new List<Demande>();

        public static void AjouterDemande(Demande dem)
        {
            listing.Add(dem);
        }

        public static List<Demande> GetListDemandes()
        {
            return listing;
        }

        public static void ViderListing()
        {
            listing.Clear();
        }
    }
}