using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class Collection
    {
        public int collectionPointId;
        public string collectionPointName;
        public string collectionPointDescription;
        public string latitude;
        public string longtitude;
        public TimeSpan? collectionTime;

        public Collection(int collectionPointId, string collectionPointName, string collectionPointDescription, string latitude, string longtitude, TimeSpan? collectionTime)
        {
            this.collectionPointId = collectionPointId;
            this.collectionPointName = collectionPointName;
            this.collectionPointDescription = collectionPointDescription;
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.collectionTime = collectionTime;

        }

        public int CollectionPointId { get; set; }
        public string CollectionPointName { get; set; }

        public string CollectionPointDescription { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }

        public TimeSpan CollectionTime { get; set; }
    }
}