using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CC
{
    public class JSONResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set; }
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public int DefaultDuration { get; set; }
        public int[] AllowedDurations { get; set; }
        public Fee Fees { get; set; }
        public int FreePhotoCount { get; set; }
        public int MaximumPhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }       
        public List<Promotion> Promotions { get; set; }
        public object[] EmbeddedContentOptions { get; set; }
        public int MaximumTitleLength { get; set; }
        public int AreaOfBusiness { get; set; }
        public int DefaultRelistDuration { get; set; }

        public class Fee
        {
            public float Bundle { get; set; }
            public float EndDate { get; set; }
            public float Feature { get; set; }
            public float Gallery { get; set; }
            public float Listing { get; set; }
            public float Reserve { get; set; }
            public float Subtitle { get; set; }
            public float TenDays { get; set; }
            public Listingfeetier[] ListingFeeTiers { get; set; }
            public float SecondCategory { get; set; }
        }

        public class Listingfeetier
        {
            public int MinimumTierPrice { get; set; }
            public float FixedFee { get; set; }
        }

        public class Promotion
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Price { get; set; }
            public int MinimumPhotoCount { get; set; }
            public float OriginalPrice { get; set; }
            public bool Recommended { get; set; }
        }
    }
}

