using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevChallengeCarguero.Services
{
    public class AddressService
    {
        public bool consultarEndereco(string address)
        {
            try
            {
                GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyD8QCttBnjg0Stya2-0nHMOEWSeXcJcIO0"));
                var request = new GeocodingRequest();
                request.Address = address;
                var response = new GeocodingService().GetResponse(request);

                if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}